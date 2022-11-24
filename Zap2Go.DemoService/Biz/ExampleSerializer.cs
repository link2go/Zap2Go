using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.DemoService.Biz
{
    public class ExampleSerializer : Zap2Go.Types.Http.Api.Webhook.Base
    {
        public override string GetStringEvent()
        {
            if (this.ObjectType == "SERVICE")
            {
                Zap2Go.Types.Biz.Webhook.SERVICE service = (Types.Biz.Webhook.SERVICE)this.DataAsType;
                if (service.MESSAGES?.Length > 0)
                {
                    var sb = new StringBuilder();
                    sb.AppendFormat("<b>Qtde Mensagens:</b>{0}</br>", service.MESSAGES.Length);
                    foreach(var message in service.MESSAGES)
                    {
                        sb.AppendFormat("</br><b>{0}:</b>\"{1}\"<i>{2:dd/MM/yyyy HH:mm}</i></br>", message.SOURCE, message.TEXT, message.CREATEDATE);
                    }

                    return sb.ToString();
                }
            }

            return base.GetStringEvent();
        }
    }
}
