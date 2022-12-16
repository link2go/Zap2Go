using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Automation.Actions
{
    public class UpdateClientInfo
    {
        public Client ClientInfo { get; set; }
        public bool PreserveOriginal { get; set; }

        public UpdateClientInfo(Client baseOne)
        {
            ClientInfo = (baseOne ?? new Client());
        }
    }
}
