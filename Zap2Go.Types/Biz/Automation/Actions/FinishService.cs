using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Automation.Actions
{
    public class FinishService : BaseAction
    {
        public string ReasonCode { get; set; }
        public int HoursIntervalNextAutomaticService { get; set; } = 24;

        public static FinishService Reset()
        {
            return new FinishService()
            {
                HoursIntervalNextAutomaticService = 0
            };
        }
    }
}
