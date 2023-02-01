using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Zap2Go.Types.Biz.Automation;
using Zap2Go.Types.Biz.Automation.Actions;
using Zap2Go.Types.Http.Api.Automation;
using Zap2Go.Types.Utils;

namespace Zap2Go.Types.Http.Api.Automation
{
    public class AutomationFlowCode
    {
        public BaseAutomationResponse SiscomItau(BaseAutomationRequest auto)
        {
            var resp = new BaseAutomationResponse();
            var messages = new ActionSendMessage();

            var step = ActionSetStep.SetNextStep(auto.CurrentStep);

            resp.Protocol = auto.Protocol;
            if (auto?.ReceivedMessage?.Text == "/RESET")
            {
                step = ActionSetStep.Restart();
                resp.Actions = new BaseAction[] { step };
            }

            switch (auto.CurrentStep)
            {
                case "START":
                    messages.SendText("Oi, [BomDia]! Aqui é a Ana, agente virtual da Siscom a serviço do *Banco Itáu*. Por gentileza, informe seu CPF para que eu possa localizar os dados do seu contrato:");
                    step = ActionSetStep.SetNextStep("SECOND");
                    break;

                case "SECOND":
                    var cpf = Regex.Replace(auto?.ReceivedMessage?.Text, @"[.][-]+", "");
                    if (cpf.Length < 11)
                    {
                        messages.SendText("Por favor, informe um CPF válido:");
                        step = ActionSetStep.SetNextStep("SECOND");
                        break;
                    }
                    else
                    {
                        var simulacao = new WebRequest().SimulacaoSiscom(auto);
                        if (simulacao.grupos.Count > 1)
                        {
                            messages.SendTextAndButtons($"Obrigado pela confirmação! {simulacao.first_name}, o contato é referente ao seu débito com o Itáu: " +
                                $"{(simulacao.grupos.Count > 1 ? $"Você possui os seguintes grupos: {simulacao.grupos.Where(x => x.identificador == "")} " : $"")}", null);
                        }
                        else if (simulacao.grupos.Count == 0)
                        {
                            messages.SendText($"{simulacao.first_name}, não encontrei nenhuma dívida para o CPF informado.");
                        }
                        else
                            messages.SendTextAndButtons($"Obrigado pela confirmação! {simulacao.first_name}, o contato é referente ao seu débito com o Itáu:" +
                                $"*Grupo 1*  Nº Contrato: {simulacao.grupos[0].contratos[0].numero_contrato}, Produto: {simulacao.grupos[0].contratos[0].nome_produto} " +
                                $"Valor atual dívida: R$" +
                                $"{simulacao.grupos[0].contratos[0].valor_original} Podemos seguir com a negociação? ", new ButtonOption[] { new ButtonOption { Id = "SECOND_01", Label = "Sim" }, new ButtonOption { Id = "SECOND_02", Label = "Não" } });
                        step = ActionSetStep.SetNextStep("THIRD");
                        break;
                    }

                case "END":
                    messages.SendTextAndButtons("Hola! Me estoy comunicando de {$.ips}. *Te estoy recordando una cita* para {$.nombre} de {$.tipo_cita} para  {$.fecha_cita} a las {$.hora_cita}. Quieres CONFIRMAR o CANCELAR esta cita?",
                    new ButtonOption[] { new ButtonOption { Id = "START_01", Label = "CONFIRMO CITA!" }, new ButtonOption { Id = "START_02", Label = "CANCELAR CITA" }, new ButtonOption { Id = "START_03", Label = "NO SOY YO" } });
                    step = ActionSetStep.SetNextStep("SECOND");
                    break;

            }
            var json = JsonConvert.SerializeObject(auto.ClientData);
            var variables = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            resp.Actions = new BaseAction[] { messages, step, new ActionSetVariables(variables), new ActionTransferService { SpecialistCode = "123" }, new ActionFinishService { ReasonCode = "TESTE" }, new ActionRegisterLog { LogInfo = " TESTE TESTANDO 123" }, new ActionAddToBlacklist { TimeoutDays = 2, ToAllWalletDevices = true } };
            return resp;
        }
    }
}
