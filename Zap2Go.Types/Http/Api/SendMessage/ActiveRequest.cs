using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Http.Api.SendMessage
{
    public class ActiveRequest
    {
        [JsonProperty("messageType")]
        public string MessageType { get; set; }

        [JsonProperty("source")]
        public int Source { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("variables")]
        public string Variables { get; set; }

        [JsonProperty("options")]
        public string Options { get; set; }

        [JsonProperty("file")]
        public string File { get; set; }

        [JsonProperty("fileName")]
        public string FileName { get; set; }

        [JsonProperty("replyMessageId")]
        public string ReplyMessageId { get; set; }

        [JsonProperty("delayTyping")]
        public int? DelayTyping { get; set; }

        [JsonProperty("expires")]
        public DateTime? Expires { get; set; }

        [JsonProperty("template")]
        public string Template { get; set; }

        [JsonProperty("instanceKey")]
        public string InstanceKey { get; set; }

        [JsonProperty("instanceSecret")]
        public string InstanceSecret { get; set; }
    }
}
