using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Zap2Go.Types.Biz.Automation;
using Zap2Go.Types.Biz.Webhook;
using Zap2Go.Types.Http.Api.Automation;
using Zap2Go.Types.Http.Api.Webhook;

namespace Zap2Go.DemoService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutomationController : ControllerBase
    {
        //para o método de automação chamado responder situações de automação.

        [HttpPost()]
        [Route("PostAutomation")]
        [AllowAnonymous]
        public ActionResult<Types.Http.Api.Automation.BaseAutomationResponse> PostAutomation([FromBody] Types.Http.Api.Automation.BaseAutomationRequest request)
        {
            var sendMessage = new ActionSendMessage { File = null, Text = "Olá, boa tarde!!" };
            var serviceFinish = new ActionServiceFinish { Notes = "FINALIZA_ATENDIMENTO", ReasonCode = null };
            var ret = new Types.Http.Api.Automation.BaseAutomationResponse()
            {
                StepToChange = "SECOND",
                Variables = request.Variables,
                Actions = new BaseAction[] { sendMessage, serviceFinish }
            };
            return Ok(ret);
        }
    }
}
