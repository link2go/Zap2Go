using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Connector
{
    public class InstanceCreateRequest
    {
        public string name { get; set; }
        public string password { get; set; }
        public bool test { get; set; }
    }
}
