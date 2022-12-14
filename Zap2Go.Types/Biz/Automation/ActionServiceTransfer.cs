using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zap2Go.Types.Biz.Automation.Actions;

namespace Zap2Go.Types.Biz.Automation
{
    public class ActionServiceTransfer : BaseAction
    {
        public bool UserQueueTransfer { get; set; } = true;
        public string UserCodeTo { get; set; }
        public int? WalletId { get; set; }

        internal override string TypeName()
        {
            return this.GetType().Name;
        }
    }
}
