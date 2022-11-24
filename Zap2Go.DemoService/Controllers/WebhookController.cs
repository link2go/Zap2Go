using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Zap2Go.DemoService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebhookController : ControllerBase
    {

        private readonly IConfiguration _config;

        public WebhookController(IConfiguration config)
        {
            _config = config;
        }

        public string DemoMode { get { return _config.GetValue<string>("DEMO:Mode"); } }
        public string DemoPath { get { return _config.GetValue<string>("DEMO:WebhookSavePath"); } }

        [HttpPost()]
        [Route("zap2go/general")]
        [AllowAnonymous]
        public HttpResponseMessage Post([FromBody] dynamic content)
        {
            //processar webhook
            string scontent = content.ToString();

            if (!System.IO.Directory.Exists(DemoPath))
                System.IO.Directory.CreateDirectory(DemoPath);

            string filecontent = null;
            string filename = null;

            if (DemoMode == "HTML")
            {
                var whook = Newtonsoft.Json.JsonConvert.DeserializeObject<Biz.ExampleSerializer>(scontent);
                filecontent = whook.GetStringEvent();
                filename = whook.GenTime.ToString("yyyy_MM_dd_HH_MM_ss") + "_" + whook.Type + "_" + whook.TransactionToken + ".html";
            }
            else
            {
                var whook = Newtonsoft.Json.JsonConvert.DeserializeObject<Zap2Go.Types.Http.Api.Webhook.Base>(scontent);
                filecontent = whook.GetStringEvent();
                filename = whook.GenTime.ToString("yyyy_MM_dd_HH_MM_ss") + "_" + whook.Type + "_" + whook.TransactionToken + ".json";
            }

            System.IO.File.WriteAllText(System.IO.Path.Combine(DemoPath, filename), filecontent);

            return new HttpResponseMessage(System.Net.HttpStatusCode.NoContent);
        }
    }
}
