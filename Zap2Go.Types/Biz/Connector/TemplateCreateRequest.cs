using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Connector
{
    public class TemplateCreateRequest
    {
        public string ownerid { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string language { get; set; }
        public SendMessageRequest template { get; set; }
    }
}
