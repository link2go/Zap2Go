using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Automation.Actions
{
    public class TransferService : BaseAction
    {
        public int? NewWalletId { get; set; }
        public string SpecialistCode { get; set; }

        internal override dynamic GetAction()
        {
            return new { NewWalletId, SpecialistCode, Name = this.GetType().Name };
        }
        public string Name { get; set; }
    }
}
