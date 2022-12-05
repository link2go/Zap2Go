using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Http.Api.Automation
{
    public class BaseAutomationResponse
    {
        //actrions: enviar_msg, variaveis para setar, gravar log, finalizar, transferir para operacao, disparar alerta, mudar step, agendar renitencia.
        public string StepToChange { get; set; }
        public Dictionary<string,object> Variables { get; set; }
        public Biz.Automation.BaseAction[] Actions { get; set; }
    }
}
