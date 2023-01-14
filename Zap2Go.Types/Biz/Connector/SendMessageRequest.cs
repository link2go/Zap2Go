using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Connector
{
    public class SendMessageRequest
    {

        public string messageType { get; set; }
        public string source { get; set; }
        public string message { get; set; }
        public string subject { get; set; }
        public string address { get; set; }
        public string name { get; set; }
        public object variables { get; set; }
        public Options options { get; set; }
        public string file { get; set; }
        public string fileName { get; set; }
        public string replyMessageId { get; set; }
        public int delayTyping { get; set; }
        public string expires { get; set; }
        public string template { get; set; }
        public string Contact { get; set; }
        public string instanceKey { get; set; }
        public string instanceSecret { get; set; }
    }

 

    public class Options
    {
        
    }

}
