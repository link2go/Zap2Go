using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zap2Go.Types.Biz.Automation.Actions;

namespace Zap2Go.Types.Http.Api.Automation
{
    public class BaseAutomationResponse
    {
        public string Protocol { get; set; }

        public List<BaseAction> Actions { get; set; } = new List<BaseAction>();
    }
}
