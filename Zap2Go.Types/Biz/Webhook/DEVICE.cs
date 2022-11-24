using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Webhook
{
    public class DEVICE : DataType
    {
        public string INTERNALCODE { get; set; }
        public string EXTERNALID { get; set; }
        public string EVENT { get; set; }

    }
}
