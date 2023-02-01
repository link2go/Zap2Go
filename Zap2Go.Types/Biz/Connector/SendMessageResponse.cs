using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Connector
{
    public class SendMessageResponse
    {
        [JsonProperty("sent")]
        public bool Sent { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("clientInstanceId")]
        public string ClientInstanceId { get; set; }
    }
}
