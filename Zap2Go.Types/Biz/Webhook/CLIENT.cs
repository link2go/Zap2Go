using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Webhook
{
    public class CLIENT : DataType
    {
        public int ID { get; set; }
        public string EXTERNALID { get; set; }
        public string DOCUMENT { get; set; }
        public string EVENT { get; set; }
        public string NAME { get; set; }
        public string PHONENUMBER { get; set; }
        public bool? WHATSAPPSTATUS { get; set; }
        public string WHATSAPPNAME { get; set; }
        public string EMAIL { get; set; }
        public bool? EMAILSTATUS { get; set; }
    }

}
