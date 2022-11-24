using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zap2Go.Types.Http.Api.Webhook;

namespace Zap2Go.Types.Biz.Webhook
{
    public class AUTOMATION :DataType
    {
        public int ID { get; set; }
        public string PROCESSOCODE { get; set; }
        public DateTime? TIMESTAMP { get; set; }
        public MESSAGE ORIGIN { get; set; }
        public string STEPFROM { get; set; }
        public string STEPTO { get; set; }
        public MESSAGE GENERATED { get; set; }
        public Dictionary<string,object> VARIABLES { get; set; }

    }
}
