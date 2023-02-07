using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Automation.Actions
{
    public class ActionFinishService : BaseAction
    {
        public string ReasonCode { get; set; }
        public int HoursIntervalNextAutomaticService { get; set; } = 24;

        public static ActionFinishService Reset()
        {
            return new ActionFinishService()
            {
                HoursIntervalNextAutomaticService = 0
            };
        }
        internal override string TypeName()
        {
            return this.GetType().Name;
        }
    }
}
