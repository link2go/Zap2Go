using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Automation.Actions
{
    public class ActionSetStep : BaseAction
    {

        public string NextStep { get; set; }

        public Dictionary<string, object> Tags { get; set; }

        public ActionSetStep(Dictionary<string, object> baseTags)
        {
            Tags = (baseTags ?? new Dictionary<string, object>());
        }

        public void SetTag(string key, object value)
        {
            Tags[key] = value;
        }

        //Retorna o proximo step setado
        public static ActionSetStep SetNextStep(string step, Dictionary<string, object> basetags = null)
        {
            var ret = new ActionSetStep(basetags);
            ret.NextStep = step;
            return ret;
        }

        public static ActionSetStep Restart()
        {
            var ret = new ActionSetStep(null);
            ret.NextStep = "START";
            return ret;
        }

        internal override string TypeName()
        {
            return this.GetType().Name;
        }
    }
}
