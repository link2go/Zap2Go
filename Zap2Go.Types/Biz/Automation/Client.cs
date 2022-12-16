using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Automation
{
    public class Client
    {
        public int Id { get; set; }
        public string Document { get; set; }
        public string ExternalId { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string NameOnChannel { get; set; }
        public string Email { get; set; }

    }
}
