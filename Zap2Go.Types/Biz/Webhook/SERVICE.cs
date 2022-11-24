using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Webhook
{
    public class SERVICE : DataType
    {
        public int ID { get; set; }
        public int? USERID { get; set; }
        public string USEREXTERNALID { get; set; }
        public string PHONENUMBER { get; set; }
        public int CLIENTID { get; set; }
        public string EXTERNALID { get; set; }
        public DateTime STARTDATE { get; set; }
        public DateTime? ENDDATE { get; set; }
        public string PROTOCOL { get; set; }
        public string REASONCODE { get; set; }
        public string NOTES { get; set; }
        public MESSAGE[] MESSAGES { get; set; }
    }
}
