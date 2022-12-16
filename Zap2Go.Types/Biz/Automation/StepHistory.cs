using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Automation
{
    public class StepHistory
    {
        public DateTime FlowStart { get; set; }
        public StepOccurence[] Timeline { get; set; }
    }

    public class StepOccurence
    {
        public int Sequence { get; set; }
        public DateTime StepDate { get; set; }
        public int TimeOnStep { get; set; }
        public string Step { get; set; }
        public Dictionary<string, object> Tags { get; set; }
    }
}
