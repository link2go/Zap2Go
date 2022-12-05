using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zap2Go.Types.Biz.Webhook;

namespace Zap2Go.Types.Http.Api.Automation
{
    public class BaseAutomationRequest
    {
        //parâmetros: carteira, dados do cliente, mensagem recebida, renitencia ocorrida, protocolo, step atual, historico recente.
        public string Trigger { get; set; } //MESSAGE, SERVICEFINISHED, renitencia

        public int WalletId { get; set; }
        public MESSAGE ReceivedMessage { get; set; }
        public Dictionary<string, object> Variables { get; set; }
    }
}
