using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Automation.Actions
{
    public class ActionChangeRetryAction : BaseAction
    {
        public bool CancelPrevious { get; set; }

        internal override string TypeName()
        {
            return this.GetType().Name;
        }
    }
}
