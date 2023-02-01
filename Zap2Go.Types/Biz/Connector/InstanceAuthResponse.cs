using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Connector
{
    public class InstanceAuthResponse
    {
        public bool success { get; set; }
        public string authcode { get; set; }
        public string message { get; set; }

        public DateTime? validuntil { get; set; }
    }


}
