using Zap2Go.Types.Http.Api.SendMessage;

namespace Zap2Go.DemoSendGrid.LogicBlock.Interface
{
    public interface IMessageLogicBlock
    {
        /// <summary>
        /// Handles and sends the message and formats a standard return
        /// </summary>
        /// <param name="request">ActiveRequest</param>
        /// <returns>ActiveResponse</returns>
        Task<ActiveResponse> ReceiveMessage(ActiveRequest request);
    }
}
