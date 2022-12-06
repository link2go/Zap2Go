using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Automation
{
    public class ActionSendMessage : BaseAction
    {
        public string Text { get; set; }
        public string File { get; set; }
        internal override string TypeName()
        {
            return "SENDMESSAGE";
        }
    }
}
