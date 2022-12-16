using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Automation.Actions
{
    public class SendMessage : BaseAction
    {
        public List<Message> Messages { get; set; } = new List<Message>();

        public void SendText(string text)
        {
            Messages.Add(new Message()
            {
                Text = text,
                Type = Message.enumMessageType.TEXT
            });
        }
    }
}
