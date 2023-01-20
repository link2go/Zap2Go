using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Connector
{
    public class InstanceCreateResponse
    {
        public string id { get; set; }
        public string token { get; set; }

        public enum EnumStatusCreateInstance { SUCCESS = 0, ERROR = 1, CREATING = 2}

        public EnumStatusCreateInstance status { get; set; } = EnumStatusCreateInstance.SUCCESS;

        public string statusMessage { get; set; }

    }


}
