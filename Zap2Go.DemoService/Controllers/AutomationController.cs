using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            if(auto.FlowCode == "SiscomItau")
            {
               return new AutomationFlowCode().SiscomItau(auto);
            }
            return null;
        }

    }
}
