using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using Zap2Go.Types.FlowCodeObjects.SiscomItau;

namespace Zap2Go.Types.Http.Api.Automation
{
    public class WebRequest
    {
        public Simulacao SimulacaoSiscom(BaseAutomationRequest auto)
        {
            var client = new RestClient("https://itau.smartcob.solutions/simulacao");

            var request = new RestRequest(Method.POST);
            request.AddHeader("api-key", "chahSo6BQuahw8sooe3iXiegMoo1iiWaaeZ5OofephohGh0IfeeH6og9quuo5Hei");
            request.AddHeader("Content-Type", "application/json");
            var body = new
            {
                identificador = auto.ClientData.Document,
                vencimento = DateTime.Now.ToString("yyyy-MM-dd"),
                tipo_simulacao = "A_VISTA"
            };
            request.AddJsonBody(body);

            IRestResponse response = client.Execute(request);
            Simulacao simulacao = JsonConvert.DeserializeObject<Simulacao>(response.Content);
            return simulacao;

        }
    }
}
