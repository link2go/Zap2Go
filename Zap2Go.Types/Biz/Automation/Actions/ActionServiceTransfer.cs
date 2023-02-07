using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Automation.Actions
{
    public class ActionServiceTransfer : BaseAction
    {
        public bool UserQueueTransfer { get; set; } = true;
        public string UserCodeTo { get; set; }
        public int? WalletId { get; set; }

        internal override string TypeName()
        {
            return GetType().Name;
        }
    }
}
