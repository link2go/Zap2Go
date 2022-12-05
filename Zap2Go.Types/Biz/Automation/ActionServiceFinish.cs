using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Automation
{
    public class ActionServiceFinish : BaseAction
    {

        public string ReasonCode { get; set; }

        public string Notes { get; set; }

        internal override string TypeName()
        {
            return "SERVICEFINISH";
        }

    }
}
