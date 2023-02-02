using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Zap2Go.Types.Biz.Automation;
using Zap2Go.Types.Biz.Automation.Actions;
using Zap2Go.Types.FlowCodeObjects.SiscomItau;

namespace Zap2Go.Types.Http.Api.Automation
{
    public class AutomationFlowCode
    {
        public BaseAutomationResponse SiscomItau(BaseAutomationRequest auto)
        {
            var resp = new BaseAutomationResponse();
            var messages = new ActionSendMessage();
            string jsonString = string.Empty;
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
                        var simulacao = new WebRequest().SimulacaoSiscom(auto, DateTime.Now.ToString("yyyy-MM-dd"), "A_VISTA");

                        if (simulacao.grupos.Count == 0)
                        {
                            messages.SendText($"{simulacao.first_name}, não encontrei nenhuma dívida para o CPF informado.");
                        }
                        else
                        {
                            StringBuilder sb = new StringBuilder();
                            int indexGrupo = 1;
                            sb.AppendLine($"Obrigado pela confirmação!");
                            sb.Append(Environment.NewLine);
                            sb.AppendLine($"{simulacao.first_name}, o contato é referente ao seu débito com o Itáu: ");
                            foreach (var grupo in simulacao.grupos)
                            {
                                var grupoStr = $"Grupo {indexGrupo}";
                                int indexContrato = 1;
                                sb.AppendLine(grupoStr);
                                foreach (var contrato in grupo.contratos)
                                {
                                    sb.Append(Environment.NewLine);
                                    sb.AppendLine($"Contrato {indexContrato}:");
                                    sb.AppendLine($"Nº Contrato: {contrato.numero_contrato}.");
                                    sb.AppendLine($"Produto {contrato.nome_produto}.");
                                    sb.AppendLine($"Valor atual dívida: R${contrato.valor_original}.");
                                    sb.Append(Environment.NewLine);
                                    sb.AppendLine("Podemos seguir com a negociação?");
                                    indexContrato++;
                                }
                                indexGrupo++;
                            }

                            messages.SendTextAndButtons(sb.ToString()
                            , new ButtonOption[] { new ButtonOption { Id = "SECOND_01", Label = "Sim" }, new ButtonOption { Id = "SECOND_02", Label = "Não" } });

                            jsonString = JsonConvert.SerializeObject(simulacao);
                        }
                        step = ActionSetStep.SetNextStep("THIRD");
                        break;
                    }

                case "THIRD":
                    var json = JsonConvert.SerializeObject(auto.Variables);
                    JObject rss = JObject.Parse(json);
                    messages.SendTextAndButtons($"{(string)rss["DadosSimulacao"]["first_name"]}, entendi! Vou lhe mostrar a opção à vista e contagem regressiva para retornar a sua saúde financeira. Estamos felizes por você! " +
                        $"Segue informações da oferta solicitada: " +
                        $"Proposta à vista de ...",
                    new ButtonOption[] { new ButtonOption { Id = "THIRD_01", Label = "Proposta à vista" }, new ButtonOption { Id = "START_02", Label = "Sugerir outra data de vencimento" }, new ButtonOption { Id = "START_03", Label = " Ver proposta parcelada" } });
                    step = ActionSetStep.SetNextStep("FOURTH");
                    break;

                case "FOURTH":
                    switch (auto.ReceivedMessage.ContentId)
                    {
                        case "THIRD_01":
                            var jsonText = JsonConvert.SerializeObject(auto.Variables);

                            messages.SendTextAndButtons("Ótimo! Vamos resumir nossa negociacao: O meio de pagamento será BOLETO, A data para pagamento DATA_PAGAMENTO, o valor da sua dívida era: R$" +
                                "Formalização do acordo é referente ao(s) produto(s) <PRODUTOS>. Contrato <CONTRATO>, vencido à <VENCIDO>." +
                                "O valor a ser pago é de R$<VALOR_PAGO>, o valor do desconto foi de R$<VALOR_DESCONTO>, um percentual de <PERCENTUAL_DESCONTO>." +
                                "Podemos confirmar seu acordo?", new ButtonOption[] { new ButtonOption { Id = "FOURTH_01", Label = "Sim" }, new ButtonOption { Id = "FOURTH_02", Label = "Não" } });
                            break;

                        case "THIRD_02":
                            messages.SendTextAndButtons("Entendi! Posso flexibilizar e encontrar a melhor data para você. Me informe qual opção abaixo você quer: ",
                            new ButtonOption[]
                            {
                                new ButtonOption { Id = $"{DateTime.Now.ToString("yyyy-MM-dd")}", Label = $"{DateTime.Now.ToString("dd/MM/yyyy")}" },
                                new ButtonOption { Id = $"{DateTime.Now.ToString("yyyy-MM-dd")}", Label = $"{DateTime.Now.ToString("dd/MM/yyyy")}" }});
                            break;
                        case "THIRD_03":
                            var simulacaoParcelada = new WebRequest().SimulacaoSiscom(auto, DateTime.Now.ToString("yyyy-MM-dd"), "PARCELADO");
                            foreach (var item in simulacaoParcelada.grupos[0].opcoesPagamento)
                            {

                            }
                            messages.SendTextAndButtons("Segue as opções que temos disponíveis para você: ",
                                 new ButtonOption[]
                                 {
                                new ButtonOption { Id = $"{DateTime.Now.ToString("yyyy-MM-dd")}", Label = $"{DateTime.Now.ToString("dd/MM/yyyy")}" },
                                new ButtonOption { Id = $"{DateTime.Now.ToString("yyyy-MM-dd")}", Label = $"{DateTime.Now.ToString("dd/MM/yyyy")}" }});
                            break;
                        default: break;
                    }
                    break;

            }
            var variables = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
            resp.Actions = new BaseAction[] { messages, step, new ActionSetVariables(variables), new ActionTransferService { SpecialistCode = "123" }, new ActionFinishService { ReasonCode = "TESTE" }, new ActionRegisterLog { LogInfo = " TESTE TESTANDO 123" }, new ActionAddToBlacklist { TimeoutDays = 2, ToAllWalletDevices = true } };
            return resp;
        }
    }
}
