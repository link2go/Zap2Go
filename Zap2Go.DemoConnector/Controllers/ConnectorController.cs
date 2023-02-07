using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zap2Go.DemoConnector.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConnectorController : ControllerBase
    {
        [HttpPost()]
        [Route("InstanceCreate")]
        public async Task<ActionResult<object>> InstanceCreate(Types.Biz.Connector.InstanceCreateRequest request)
        {
            //objetivo: criar uma nova instância para execução

            return Ok(new Types.Biz.Connector.InstanceCreateResponse());
        }


        [HttpPost()]
        [Route("InstanceRestart")]
        public async Task<ActionResult<object>> InstanceRestart(Types.Biz.Connector.InstanceRestartRequest request)
        {
            //objetivo: reiniciar a execução da instância

            return Ok();
        }

        [HttpPost()]
        [Route("InstanceCancel")]
        public async Task<ActionResult<object>> InstanceCancel(Types.Biz.Connector.InstanceCancelRequest request)
        {
            //objetivo: cancelar/excluir instância

            return Ok();
        }

        [HttpPost()]
        [Route("InstanceSetProfile")]
        public async Task<ActionResult<object>> InstanceSetProfile(Types.Biz.Connector.InstanceSetProfileRequest request)
        {
            //objetivo: setar os dados de perfil da instância
            return Ok();
        }
        [HttpPost()]
        [Route("CheckAddress")]
        public async Task<ActionResult<Types.Biz.Connector.CheckAddressResponse[]>> CheckAddress([FromBody] Types.Biz.Connector.CheckAddressRequest request)
        {
            return Ok(new Types.Biz.Connector.CheckAddressResponse[] { }); //retorna um array com o tratamento de cada address do array de address
        }


        [HttpPost()]
        [Route("SendMessage")]
        public async Task<ActionResult<Types.Biz.Connector.SendMessageResponse>> SendMessage([FromBody] Types.Biz.Connector.SendMessageRequest request)
        {
            return Ok(new Types.Biz.Connector.SendMessageResponse());
        }

        [HttpPost()]
        [Route("TemplateCreate")]
        public async Task<ActionResult<Types.Biz.Connector.TemplateCreateResponse>> TemplateCreate([FromBody] Types.Biz.Connector.TemplateCreateRequest request)
        {
            return Ok(new Types.Biz.Connector.TemplateCreateResponse());
        }

        [HttpPost()]
        [Route("InstanceAuth")]
        public async Task<ActionResult<Types.Biz.Connector.InstanceAuthResponse>> InstanceAuth([FromBody] Types.Biz.Connector.InstanceAuthRequest request)
        {
            return Ok(new Types.Biz.Connector.InstanceAuthResponse());
        }

        [HttpPost()]
        [Route("InstanceDisconnect")]
        public async Task<ActionResult<object>> Instancedisconnect([FromBody] Types.Biz.Connector.InstanceDisconnectRequest request)
        {
            return Ok();
        }
    }
}
