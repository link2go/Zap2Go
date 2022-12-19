using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            var resp = new BaseAutomationResponse();
            var messages = new SendMessage();
            resp.Protocol = auto.Protocol;

            if (auto?.ReceivedMessage?.Text == "/RESET")
            {
                resp.Actions.Add(SetStep.Restart());
                return Ok(resp);
            }

            switch (auto.CurrentStep)
            {
                case "START":
                    messages.SendTextAndButtons("Hola! Me estoy comunicando de {$.ips}. *Te estoy recordando una cita* para {$.nombre} de {$.tipo_cita} para {$.fecha_cita} a las {$.hora_cita}. Quieres CONFIRMAR o CANCELAR esta cita?",
                        new ButtonOption[] { new ButtonOption { Id = "START_01", Label = "CONFIRMO CITA!" }, new ButtonOption { Id = "START_02", Label = "CANCELAR CITA" }, new ButtonOption { Id = "START_03", Label = "NO SOY YO" } });
                    resp.Actions.Add(SetStep.SetNextStep("SECOND"));
                    break;

                case "SECOND":
                    switch (auto.ReceivedMessage.Text)
                    {
                        case "START_01":
                            messages.SendText("Perfecto, muchas gracias!  Recuerda que al ser una cita *PRESENCIAL* debes llegar 20 minutos antes con la documentación del paciente. Si necesitas cancelar tu cita puedes llamar 24x7 al teléfono (604) 444 4080. Muchas gracias y [BuenosDiasSalida]");
                            resp.Actions.Add(SetStep.SetNextStep("END"));
                            break;
                        case "START_02":
                            messages.SendText("Entiendo, muchas gracias. Tu cita ha sido cancelada. Recuerda que si deseas reagendar, lo puedes hacer a través de nuestro teléfono: (604) 444 4080.  Muchas gracias!");
                            resp.Actions.Add(SetStep.SetNextStep("END"));
                            break;
                        case "START_03":
                            messages.SendText("Disculpa la molestia. Muchas gracias que tengas un feliz día!");
                            resp.Actions.Add(SetStep.SetNextStep("NO_SOY_YO"));
                            break;
                        default:
                            messages.SendTextAndButtons("Hola! Me estoy comunicando de {$.ips}. *Te estoy recordando una cita* para {$.nombre} de {$.tipo_cita} para  {$.fecha_cita} a las {$.hora_cita}. Quieres CONFIRMAR o CANCELAR esta cita?",
                            new ButtonOption[] { new ButtonOption { Id = "START_01", Label = "CONFIRMO CITA!" }, new ButtonOption { Id = "START_02", Label = "CANCELAR CITA" }, new ButtonOption { Id = "START_03", Label = "NO SOY YO" } });
                            resp.Actions.Add(SetStep.SetNextStep("SECOND"));
                            break;
                    }
                    break;

                case "END":
                    messages.SendTextAndButtons("Hola! Me estoy comunicando de {$.ips}. *Te estoy recordando una cita* para {$.nombre} de {$.tipo_cita} para  {$.fecha_cita} a las {$.hora_cita}. Quieres CONFIRMAR o CANCELAR esta cita?",
                    new ButtonOption[] { new ButtonOption { Id = "START_01", Label = "CONFIRMO CITA!" }, new ButtonOption { Id = "START_02", Label = "CANCELAR CITA" }, new ButtonOption { Id = "START_03", Label = "NO SOY YO" } });
                    resp.Actions.Add(SetStep.SetNextStep("SECOND"));
                    break;

            }

            resp.Actions.Add(messages);

            return Ok(resp);

        }
        
    }
}
