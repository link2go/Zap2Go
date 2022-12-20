using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
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
            var messages = new SendMessage();

            var step = SetStep.SetNextStep(auto.CurrentStep);

            resp.Protocol = auto.Protocol;
            if (auto?.ReceivedMessage?.Text == "/RESET")
            {
                step = SetStep.Restart();
                resp.Actions = new BaseAction[] { step };
                return Ok(resp);
            }
            switch (auto.CurrentStep)
            {
                case "START":
                    messages.SendTextAndButtons("Hola! Me estoy comunicando de {$.ips}. *Te estoy recordando una cita* para {$.nombre} de {$.tipo_cita} para {$.fecha_cita} a las {$.hora_cita}. Quieres CONFIRMAR o CANCELAR esta cita?",
                        new ButtonOption[] { new ButtonOption { Id = "START_01", Label = "CONFIRMO CITA!" }, new ButtonOption { Id = "START_02", Label = "CANCELAR CITA" }, new ButtonOption { Id = "START_03", Label = "NO SOY YO" } });
                    step = SetStep.SetNextStep("SECOND");
                    break;

                case "SECOND":
                    switch (auto?.ReceivedMessage?.Text)
                    {
                        case "CONFIRMO CITA!":
                            messages.SendText("Perfecto, muchas gracias!  Recuerda que al ser una cita *PRESENCIAL* debes llegar 20 minutos antes con la documentación del paciente. Si necesitas cancelar tu cita puedes llamar 24x7 al teléfono (604) 444 4080. Muchas gracias y [BuenosDiasSalida]");
                            step = SetStep.SetNextStep("CONFIRMADA");
                            break;
                        case "CANCELAR CITA":
                            //Call API
                            var ret = new WebRequest().CancelaCitaHumanitas(auto.Variables);
                            messages.SendText("Entiendo, muchas gracias. Tu cita ha sido cancelada. Recuerda que si deseas reagendar, lo puedes hacer a través de nuestro teléfono: (604) 444 4080.  Muchas gracias!");
                            step = SetStep.SetNextStep("CANCELADA");
                            break;
                        case "NO SOY YO":
                            messages.SendText("Disculpa la molestia. Muchas gracias que tengas un feliz día!");
                            step = SetStep.SetNextStep("NO_SOY_YO");
                            break;
                        default:
                            messages.SendTextAndButtons("Hola! Me estoy comunicando de {$.ips}. *Te estoy recordando una cita* para {$.nombre} de {$.tipo_cita} para  {$.fecha_cita} a las {$.hora_cita}. Quieres CONFIRMAR o CANCELAR esta cita?",
                            new ButtonOption[] { new ButtonOption { Id = "START_01", Label = "CONFIRMO CITA!" }, new ButtonOption { Id = "START_02", Label = "CANCELAR CITA" }, new ButtonOption { Id = "START_03", Label = "NO SOY YO" } });
                            step = SetStep.SetNextStep("SECOND");
                            break;
                    }
                    break;

                case "END":
                    messages.SendTextAndButtons("Hola! Me estoy comunicando de {$.ips}. *Te estoy recordando una cita* para {$.nombre} de {$.tipo_cita} para  {$.fecha_cita} a las {$.hora_cita}. Quieres CONFIRMAR o CANCELAR esta cita?",
                    new ButtonOption[] { new ButtonOption { Id = "START_01", Label = "CONFIRMO CITA!" }, new ButtonOption { Id = "START_02", Label = "CANCELAR CITA" }, new ButtonOption { Id = "START_03", Label = "NO SOY YO" } });
                    step = SetStep.SetNextStep("SECOND");
                    break;

            }
            resp.Actions = new BaseAction[] { messages, step };

            return Ok(resp);

        }

    }
}
