using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Automation.Actions
{
    public class ActionAddToBlacklist : BaseAction
    {
        public bool ToAllWalletDevices { get; set; } = true;
        public int TimeoutDays { get; set; }

        internal override string TypeName()
        {
            return this.GetType().Name;
        }
    }
}
