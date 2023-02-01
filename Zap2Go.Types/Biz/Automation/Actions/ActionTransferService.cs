using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Automation.Actions
{
    public class ActionTransferService : BaseAction
    {
        public int? NewWalletId { get; set; }
        public string SpecialistCode { get; set; }

        internal override string TypeName()
        {
            return this.GetType().Name;
        }
    }
}
