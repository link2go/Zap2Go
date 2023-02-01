using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Automation.Actions
{
    public class SendAlert
    {
        public enum enumAlertScope { IT = 1, OPERATION = 2, MANAGEMENT = 3, GENERAL = 4 }
        public enumAlertScope Scope { get; set; } = enumAlertScope.IT;
    }
}
