using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Connector
{
    public class InstanceCancelRequest
    {

        public string id { get; set; }
        public string token { get; set; }
        public string password { get; set; }
    }
}
