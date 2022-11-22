using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [HttpPost()]
        [Route("zap2go/general")]
        [AllowAnonymous]
        public HttpResponseMessage Post([FromBody] dynamic content)
        {
            //processar webhook

            return new HttpResponseMessage(System.Net.HttpStatusCode.NoContent);
        }
    }
}
