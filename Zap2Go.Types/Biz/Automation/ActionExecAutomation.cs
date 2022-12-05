using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zap2Go.Types.Http.Api.Automation;

namespace Zap2Go.Types.Biz.Automation
{
    public class ActionExecAutomation : BaseAction
    {
        public string Code { get; set; }

        internal override string TypeName()
        {
            return "EXECAUTOMATION";
        }

    }
}
