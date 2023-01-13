using Microsoft.AspNetCore.Mvc;
using Zap2Go.DemoSendGrid.LogicBlock.Interface;
using Zap2Go.Types.Http.Api.SendMessage;

namespace Zap2Go.DemoSendGrid.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageLogicBlock _messageLogicBlock;

        public MessageController(IMessageLogicBlock messageLogicBlock)
        {
            _messageLogicBlock = messageLogicBlock;
        }

        /// <summary>
        /// Handles and sends the message and formats a standard return
        /// </summary>
        /// <param name="request">ActiveRequest</param>
        /// <returns>ActiveResponse</returns>
        [Route("Receive")]
        [HttpPost()]
        public async Task<IActionResult> Receive([FromBody] ActiveRequest request)
        {
            var result = await _messageLogicBlock.ReceiveMessage(request);

            if (result.Sent)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
