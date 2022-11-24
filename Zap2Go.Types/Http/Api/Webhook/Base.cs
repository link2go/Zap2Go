using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zap2Go.Types.Biz.Webhook;

namespace Zap2Go.Types.Http.Api.Webhook
{
    public class Base
    {
        public string Type { get; set; }
        public string TransactionToken { get; set; }
        public DateTime GenTime { get; set; }
        public string WalletName { get; set; }
        public int? WalletId { get; set; }
        public string ObjectType { get; set; }

        private string _Data;
        public object Data
        {
            set
            {
                _Data = Newtonsoft.Json.JsonConvert.SerializeObject(value);
            }
        }



        public DataType DataAsType
        {
            get
            {
                var type = System.Type.GetType("Zap2Go.Types.Biz.Webhook." + this.ObjectType, false, true);

                if (type == null)
                    return null;

                var ret = Newtonsoft.Json.JsonConvert.DeserializeObject(_Data, type);
                return (DataType)ret;

            }
        }

        public virtual string GetStringEvent()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

    }



}
