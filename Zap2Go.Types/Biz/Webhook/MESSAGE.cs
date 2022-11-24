using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Webhook
{
    public class MESSAGE : DataType
    {
        public int ID { get; set; }
        public int? QUEUEID { get; set; }
        public string TYPE { get; set; }
        public string SOURCE { get; set; }
        public int? DEVICEID { get; set; }
        public string PHONENUMBER { get; set; }
        public int CLIENTID { get; set; }
        public string EXTERNALID { get; set; }
        public int? USERID { get; set; }
        public string USEREXTERNALID { get; set; }
        public string TEXT { get; set; }
        public string FILE { get; set; }
        public string FILENAME { get; set; }
        public string BUTTONS { get; set; }
        public DateTime? CREATEDATE { get; set; }
        public DateTime? SENTDATE { get; set; }
        public DateTime? DELIVERYDATE { get; set; }
        public DateTime? READDATE { get; set; }
        public string ERROR { get; set; }
    }
}
