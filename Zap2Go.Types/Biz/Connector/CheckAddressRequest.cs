﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Connector
{
    public class CheckAddressRequest
    {
        public string id { get; set; }
        public string token { get; set; }
        public string password { get; set; }

        public string[] address { get; set; } // array com um ou mais endereços para serem checados
    }
}
