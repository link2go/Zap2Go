using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Automation
{
    public class Message
    {
        public enum enumMessageType { TEXT = 1, FILE = 2, BUTTON = 3, MEDIA = 4, LINK = 5, CONTACT = 6,  OPTIONLIST = 7,  BUTTONACTIONS = 8 };

        public enumMessageType Type { get; set; }
        public string Text { get; set; }
        public string ContentId { get; set; }
        public string FileContent { get; set; }
        public string FileName { get; set; }
        public ButtonOption[] Buttons { get; set; }
        public OptionsLits[] Options { get; set; }

        public DateTime? ScheduleFor { get; set; }
    }

    public class ButtonOption
    {
        public string Id { get; set; }
        public string Label { get; set; }
    }
    public class OptionsLits
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }

    }
}
