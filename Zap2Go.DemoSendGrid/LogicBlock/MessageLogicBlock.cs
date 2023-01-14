using Zap2Go.DemoSendGrid.LogicBlock.Interface;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Text.RegularExpressions;
using System.Net;
using Zap2Go.Types.Biz.Connector;

namespace Zap2Go.DemoSendGrid.LogicBlock
{
    /// <summary>
    /// Handles events related to sending messages
    /// </summary>
    public class MessageLogicBlock : IMessageLogicBlock
    {
        private readonly IConfiguration _config;
        private readonly ILogger<MessageLogicBlock> _logger;

        public MessageLogicBlock(IConfiguration config, ILogger<MessageLogicBlock> logger)
        {
            _config = config;
            _logger = logger;
        }

        /// <summary>
        /// Handles and sends the message and formats a standard return
        /// </summary>
        /// <param name="request">SendMessageRequest</param>
        /// <returns>SendMessageResponse</returns>
        public async Task<SendMessageResponse> ReceiveMessage(SendMessageRequest request)
        {
            SendMessageResponse result = new SendMessageResponse();
            result.Sent = false;
            result.Message = _config.GetValue<string>("Message:Error");

            try
            {
                var instanceKey = _config.GetValue<string>("Instance:Key");
                var instanceSecret = _config.GetValue<string>("Instance:Secret");
                var instanceType = _config.GetValue<string>("Instance:Type");

                //Validate if the request has access credentials
                if (request.InstanceKey != instanceKey || request.InstanceSecret != instanceSecret)
                    return result;


                var apiKey = _config.GetValue<string>("SendGrid:Secret");
                var client = new SendGridClient(new SendGridClientOptions { ApiKey = apiKey, HttpErrorAsException = true });

                var from = new EmailAddress(_config.GetValue<string>("Message:Email"), _config.GetValue<string>("Message:Name"));
                var subject = request.Subject;
                var to = new EmailAddress(request.Address);
                var plainTextContent = Regex.Replace(request.Message, "<[^>]*>", string.Empty);
                var htmlContent = request.Message;

                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg).ConfigureAwait(false);

                // Check if the email was sent successfully
                if (response.StatusCode == HttpStatusCode.Accepted)
                {
                    result.Id = "2E8843CA5233E42C336C";
                    result.Sent = true;
                    result.Message = _config.GetValue<string>("Message:Success");
                }

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                _logger.LogError(ex.InnerException?.Message);
            }

            return result;
        }
    }
}
