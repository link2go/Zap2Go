using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Automation.Actions
{
    public class SetStep : BaseAction
    {

        public string NextStep { get; set; }

        public Dictionary<string, object> Tags { get; set; } 

        public SetStep(Dictionary<string, object> baseTags)
        {
            Tags = (baseTags ?? new Dictionary<string, object>());
        }

        public void SetTag(string key, object value)
        {
            Tags[key] = value;
        }


        //Retorna o proximo step setado
        public static SetStep SetNextStep(string step, Dictionary<string, object> basetags = null)
        {
            var ret = new SetStep(basetags);
            ret.NextStep = step;
            return ret;
        }

        public static SetStep Restart()
        {
            var ret = new SetStep(null);
            ret.NextStep = "START";
            return ret;
        }

    }
}
