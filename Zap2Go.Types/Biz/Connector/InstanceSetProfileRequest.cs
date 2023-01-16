using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Connector
{
    public class InstanceSetProfileRequest
    {
        public string id { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string photo { get; set; }
        public string url { get; set; }


    }
}
