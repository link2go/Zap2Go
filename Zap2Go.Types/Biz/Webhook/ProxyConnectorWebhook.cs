using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Webhook
{
    public class PROXYCONNECTORWEBHOOK
    {
        public enum EnumEventType
        {
            MESSAGE = 1,        //usar para mensagem recebida e eventos de envio, entrega, leitura, etc. Sempre informar "instance" e "cliente"
            INSTANCE = 2,       //usar para eventos de conexao/desconexao/envio do qr code
            CLIENT = 3,    
            TEMPLATE = 4,
            UNDEFINED = 99      //nao usar
        }
        public enum EnumEventDirectionType { FROMME = 1, FROMCLIENT = 2 }   //FROMCLIENT: quando é mensagem recebida. FROMME - todos os outros casos

        public string supplier { get; set; }                //colocar o mesmo cadastrado no fornecedor(nome do tipo_instancia)
        //instancia
        public ProxyWebhookInstance instance { get; set; }  //sempre é criado no mínimo identificando o id da instância
        public EnumEventType eventType { get; set; } = EnumEventType.UNDEFINED;

        public EnumEventDirectionType eventDirectionType { get; set; }

        public DateTime moment { get; set; } = DateTime.Now;    //INFORMAR NO FUSO DO BRASIL

        public ProxyWebhookClient client { get; set; }  //sempre informar, exceto em eventos da instancia
        public ProxyWebhookMessage message { get; set; }

        public ProxyWebhookError error { get; set; }

        public ProxyWebhookTemplate template { get; set; }

        public string transactionid { get; set; }

    }

    public class ProxyWebhookError
    {
        public string code { get; set; }

        public string message { get; set; }

        public string content { get; set; }
    }

    public class ProxyWebhookClient
    {
        public enum EnumClientEventType { NEW = 1, ERROR = 2, PRESENT = 3, ABSENT = 4, BLACKLISTED = 5, NOTEXISTS = 6, UNDEFINED = 99 }
        public EnumClientEventType eventType { get; set; } = EnumClientEventType.UNDEFINED;


        public string address { get; set; }     //identificacao publica do cliente - telefone ou e-mail (obrigatório)
        public string name { get; set; }
        public string photo { get; set; }
        public string profile { get; set; }
        public string instanceid { get; set; }
    }


    public class ProxyWebhookMessage
    {


        public enum EnumMessageType { TEXT = 0, IMAGE = 1, DOCUMENT = 2, VIDEO = 3, AUDIO = 4, REACTION = 5, FILE = 6, OPTION = 7, LOCATION = 8, UNDEFINED = 99 }
        public enum EnumMessageEventType
        {
            RECEIVE = 1, SENT = 2, DELIVERY = 3, READ = 4, CLICK = 5, NOTSENT = 6
        }
        public EnumMessageEventType eventType { get; set; }

        public EnumMessageType messageType { get; set; } = EnumMessageType.UNDEFINED; //informar o correto na menagem recebida
        public string id { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public string file { get; set; }
        public string fileName { get; set; }
        public string option { get; set; }          // id do botao clicado, se aplicável
        public string refId { get; set; }           //ide da mensagem respondida, se aplicavel
        public string reaction { get; set; }        //reacao do usuário, se aplicável


    }

    public class ProxyWebhookInstance
    {
        public enum EnumInstanceEventType 
        { 
            CONNECTED = 1,      //instancia foi conectada / está conectada
            DISCONNECTED = 2,   //instancia foi desconectada / está desconectada
            CREATED = 3,        //instancia foi criada
            EXCLUDED = 4,       //instancia foi excluida
            READY = 5,          //instancia está pronta (informar o qrcode base 64 no content)
            BLOCKED = 6,
            UNDEFINED = 99      //usar quando não for evento de instancia
        }
        public EnumInstanceEventType eventType { get; set; } = EnumInstanceEventType.UNDEFINED;
        public string key { get; set; }             //id da instancia
        public string content { get; set; }         //incluira o QRCODE ou o número de telefone, se aplicável

    }

    public class ProxyWebhookTemplate
    {
        public enum EnumTemplateEventType { NEW = 1, PROCESSING = 2, APPROVED = 3, REJECTED = 4, CANCELLED = 5, UNDEFINED = 99 }
        public EnumTemplateEventType eventType { get; set; } = EnumTemplateEventType.UNDEFINED;

        public string name { get; set; }         
        public string log { get; set; }
        public string language { get; set; }


    }
}
