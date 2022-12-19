using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
        public void SendTextAndButtons(string text, ButtonOption[] buttons)
        {
            Messages.Add(new Message()
            {
                Text = text,
                Type = Message.enumMessageType.BUTTON,
                Buttons = buttons
            });
        }
        public void SendTextAndOptions(string text)
        {
            Messages.Add(new Message()
            {
                Text = text,
                Type = Message.enumMessageType.OPTIONLIST
            });
        }
        internal override dynamic GetAction()
        {
            return new { Messages, Name = this.GetType().Name };
        }

        public string Name { get; set; }
    }
}
