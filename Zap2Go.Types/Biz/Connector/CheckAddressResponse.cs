using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Connector
{
    public class CheckAddressResponse
    {
        public string address { get; set; }
        public enum EnumCheckAddressResult { NOT_CHECKED = 0, SUCCESS = 1, ERROR = 2, TEMPORARY_UNAVAILABLE = 3 }

        public EnumCheckAddressResult result { get; set; } = EnumCheckAddressResult.NOT_CHECKED;
        public string clearedAddress { get; set; }
        public string log { get; set; }
    }
}
