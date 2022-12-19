using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Automation.Actions
{
    public class RegisterLog : BaseAction
    {
        public string LogInfo { get; set; }

        internal override dynamic GetAction()
        {
            return new { LogInfo = LogInfo, Name = this.GetType().Name };
        }
        public string Name { get; set; }
    }
}
