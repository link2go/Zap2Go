using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Zap2Go.Types.Utils
{
    public static class Extensions
    {

        public static void FixValueWithJsonElement(this Dictionary<string, object> dic, bool recursive)
        {
            if (dic == null || dic.Count == 0)
                return;

            foreach (var key in dic.Keys)
            {
                var value = dic[key];
                if (value != null)
                {
                    if (value.GetType() == dic.GetType())
                    {
                        if (recursive)
                            ((Dictionary<string, object>)value).FixValueWithJsonElement(recursive);
                    }
                    else
                    {
                        dic[key] = value.ValueFromJsonElement();
                        if (dic[key] != null && dic[key].GetType().IsArray)
                        {
                            var arr = ((object[])dic[key]);
                            for (int i = 0; i < arr.Length; i++)
                            {
                                if (arr[i] != null)
                                    arr[i] = arr[i].ValueFromJsonElement();
                            }
                        }

                    }
                }
            }


        }

        public static object ValueFromJsonElement(this object obj)
        {
            if (obj == null)
                return null;

            if (obj.GetType() == typeof(JObject))
            {
                var seri = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                var desser = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(seri);
                desser.FixValueWithJsonElement(true);

                return desser;
            }

            if (obj.GetType() == typeof(System.Text.Json.JsonElement))
            {
                var ret = Newtonsoft.Json.JsonConvert.DeserializeObject(((JsonElement)obj).GetRawText());
                return ret;
            }

            if (obj.GetType() == typeof(JArray))
            {
                var ret = ((JArray)obj).ToObject<List<object>>().ToArray();

                //var ret = Newtonsoft.Json.JsonConvert.DeserializeObject(((JArray)obj).ToString());
                return ret;
            }


            return obj;
        }
    }
}
