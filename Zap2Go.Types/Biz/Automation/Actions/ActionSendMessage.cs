using System.Collections.Generic;

namespace Zap2Go.Types.Biz.Automation.Actions
{
    public class ActionSendMessage : BaseAction
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
        public void SendTextAndOptions(string text, OptionsLits[] options)
        {
            Messages.Add(new Message()
            {
                Text = text,
                Type = Message.enumMessageType.OPTIONLIST,
                Options = options
            });
        }

        internal override string TypeName()
        {
            return this.GetType().Name;
        }
    }
}
