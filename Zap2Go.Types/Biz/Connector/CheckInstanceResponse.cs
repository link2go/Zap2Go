using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Connector
{
    public class CheckInstanceResponse
    {
        public enum EnumCheckInstanceResult { NOT_CHECKED = 0, ONLINE = 1, ONLINE_CONNECTED = 2, ONLINE_DISCONNECTED = 3, OFFLINE = 4 }

        public EnumCheckInstanceResult result { get; set; } = EnumCheckInstanceResult.NOT_CHECKED;
        public string log { get; set; }
    }
}
