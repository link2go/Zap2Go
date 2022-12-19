using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zap2Go.Types.Biz.Automation.Actions;

namespace Zap2Go.Types.Biz.Automation
{
    public class ActionServiceFinish : BaseAction
    {
        public string ReasonCode { get; set; }
        public string Notes { get; set; }

        internal override dynamic GetAction()
        {
            return new { ReasonCode, Notes, Name = this.GetType().Name };
        }
        public string Name { get; set; }
    }
}
