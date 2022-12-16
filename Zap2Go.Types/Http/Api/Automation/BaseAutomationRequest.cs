using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zap2Go.Types.Biz.Automation;

namespace Zap2Go.Types.Http.Api.Automation
{
    public class BaseAutomationRequest
    {
        public int WalletId { get; set; }
        public string FlowCode { get; set; }
        public string Protocol { get; set; }
        public Client ClientData { get; set; }
        public Message ReceivedMessage { get; set; }

        public string CurrentStep { get; set; }
        public int TimesAtThisStep { get; set; }
        public StepHistory FlowTimeline { get; set; }

        public string ResubmitToken { get; set; }
        public Dictionary<string, object> Variables { get; set; }


    }
}
