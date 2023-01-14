using Zap2Go.Types.Biz.Connector;

namespace Zap2Go.DemoSendGrid.LogicBlock.Interface
{
    public interface IMessageLogicBlock
    {
        /// <summary>
        /// Handles and sends the message and formats a standard return
        /// </summary>
        /// <param name="request">SendMessageRequest</param>
        /// <returns>SendMessageResponse</returns>
        Task<SendMessageResponse> ReceiveMessage(SendMessageRequest request);
    }
}
