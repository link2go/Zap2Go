using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Automation.Actions
{
    public class ChangeRetryAction : BaseAction
    {
        public bool CancelPrevious { get; set; }

        internal override dynamic GetAction()
        {
            return new { CancelPrevious = CancelPrevious, Name = this.GetType().Name };
        }
        public string Name { get; set; }
    }
}
