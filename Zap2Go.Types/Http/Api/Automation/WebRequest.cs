using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Zap2Go.Types.Utils;

namespace Zap2Go.Types.Http.Api.Automation
{
    public class WebRequest
    {
        public string CancelaCitaHumanitas(Dictionary<string, object> variables)
        {
            string url = "https://lab.humanitas.host/cita-especialistas/";
            var client = new RestClient(url);

            var json = JsonConvert.SerializeObject(variables);
            var obj = JsonConvert.DeserializeObject<dynamic>(json)!;

            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(new
            {
                token = "81548d8912159ef3fd63c036dc75bf04",
                celular = obj.cedula.ToString(),
                idCita = obj.codigo_cita.ToString(),
                ctipo_documento = obj.tipo_documento.ToString(),
                cidentificacion = obj.cedula.ToString()
            });

            var response = client.Execute(request);
            return response.Content;
        }
    }
}
