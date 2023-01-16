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
        [Route("SendMessage")]
        public async Task<ActionResult<object>> SendMessage([FromBody] Types.Biz.Connector.SendMessageRequest request)
        {



            return Ok(new Types.Biz.Connector.SendMessageResponse());
        }


    }
}
