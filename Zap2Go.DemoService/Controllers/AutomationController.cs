using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Zap2Go.Types.Biz.Automation;
using Zap2Go.Types.Biz.Automation.Actions;
using Zap2Go.Types.Http.Api.Automation;
using Zap2Go.Types.Utils;

namespace Zap2Go.DemoService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutomationController : ControllerBase
    {
        [HttpPost()]
        [Route("zap2go/autodemo")]
        [AllowAnonymous]
        public ActionResult<BaseAutomationResponse> AutoDemo([FromBody] BaseAutomationRequest auto)
        {
            //conversao de value json generico para especifico
            auto.Variables.FixValueWithJsonElement(true);

            var resp = new BaseAutomationResponse();
            var newvars = new SetVariables(auto.Variables);
            var messages = new SendMessage();


            if (auto?.ReceivedMessage?.Text == "/RESET")
            {
                resp.Actions.Add(SetStep.Restart());
                return Ok(resp);
            }


            switch (auto.CurrentStep)
            {
                case "START":
                    messages.SendText("Conheça nosso cardápio");
                    //...

                    resp.Actions.Add(SetStep.SetNextStep("PIZZA"));
                    break;

                case "PIZZA":
                    //...

                    resp.Actions.Add(SetStep.SetNextStep("BEBIDA"));
                    break;

                case "BEBIDA":

                    resp.Actions.Add(SetStep.SetNextStep("DESCONTO"));
                    break;

                case "DESCONTO":

                    resp.Actions.Add(SetStep.SetNextStep("END"));
                    break;

            }


            resp.Actions.Add(newvars);
            resp.Actions.Add(messages);

            return Ok(resp);

        }
    }
}
