using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Automation.Actions
{
    public class SetVariables : BaseAction
    {
        public Dictionary<string, object> NewValues { get; set; } 
        public bool PreserveOriginal { get; set; }

        public SetVariables(Dictionary<string, object> baseDic)
        {
            NewValues = (baseDic ?? new Dictionary<string, object>());
        }

        public void SetVariable(string key, object value)
        {
            if (PreserveOriginal && NewValues.ContainsKey(key))
                return;

            NewValues[key] = value;
        }
    }
}
