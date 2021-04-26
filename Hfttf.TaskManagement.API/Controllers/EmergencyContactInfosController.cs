using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Commands;
using Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.API.Controllers
{
    [Route("api/TaskManagementApi/[controller]/[action]")]
    [ApiController]
    public class EmergencyContactInfosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EmergencyContactInfosController> _logger;

        public EmergencyContactInfosController(IMediator mediator, ILogger<EmergencyContactInfosController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// You can use it to instert a EmergencyContactInfo.
        /// </summary>
        /// <param name="emergencyContactInfoInsertCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(EmergencyContactInfoInsertCommand), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Response>> Insert([FromBody] EmergencyContactInfoInsertCommand emergencyContactInfoInsertCommand)
        {
            var response = await _mediator.Send(emergencyContactInfoInsertCommand);
            return Ok(response);
        }

        /// <summary>
        /// You can use it to update a EmergencyContactInfo Assign.
        /// </summary>
        /// <param name="emergencyContactInfoUpdateCommand">Hello World</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(EmergencyContactInfoUpdateCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Update([FromBody] EmergencyContactInfoUpdateCommand emergencyContactInfoUpdateCommand)
        {
            var result = await _mediator.Send(emergencyContactInfoUpdateCommand);
            return Ok(result);
        }

        /// <summary>
        /// You can use it to delete a EmergencyContactInfo
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EmergencyContactInfoDeleteCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            var result = await _mediator.Send(new EmergencyContactInfoDeleteCommand() { Id = id });
            return Ok(result);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="emergencyContactInfoDetailQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetById([FromQuery] EmergencyContactInfoDetailQuery emergencyContactInfoDetailQuery)
        {
            var response = await _mediator.Send(emergencyContactInfoDetailQuery);
            return Ok(response);
        }

        /// <summary>
        /// You can call it to the whole EmergencyContactInfo list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetList()
        {
            var response = await _mediator.Send(new EmergencyContactInfoListQuery());
            return Ok(response);
        }

        /// <summary>
        /// You can call it to the whole EmergencyContactInfo list by User Id.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetListByUserId([FromQuery] EmergencyContactInfoListByUserIdQuery emergencyContactInfoListByUserIdQuery)
        {
            var response = await _mediator.Send(emergencyContactInfoListByUserIdQuery);
            return Ok(response);
        }


    }
}
