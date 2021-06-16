using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.ResourceViewModel;
using Hfttf.TaskManagement.Service.Services.EducationInformations.Commands;
using Hfttf.TaskManagement.Service.Services.EducationInformations.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.API.Controllers
{
    [Route("api/TaskManagementApi/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = UserRoles.User + "," + UserRoles.Admin)]
    public class EducationInformationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EducationInformationsController> _logger;

        public EducationInformationsController(IMediator mediator, ILogger<EducationInformationsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        /// <summary>
        /// You can use it to instert a EducationInformation.
        /// </summary>
        /// <param name="educationInformationInsertCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(EducationInformationInsertCommand), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Response>> Insert([FromBody] EducationInformationInsertCommand educationInformationInsertCommand)
        {
            var response = await _mediator.Send(educationInformationInsertCommand);
            return Ok(response);
        }

        /// <summary>
        /// You can use it to update a EducationInformation Assign.
        /// </summary>
        /// <param name="educationInformationUpdateCommand">Hello World</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(EducationInformationUpdateCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Update([FromBody] EducationInformationUpdateCommand educationInformationUpdateCommand)
        {
            var result = await _mediator.Send(educationInformationUpdateCommand);
            return Ok(result);
        }

        /// <summary>
        /// You can use it to delete a EducationInformation
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EducationInformationDeleteCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            var result = await _mediator.Send(new EducationInformationDeleteCommand() { Id = id });
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="educationInformationDetailQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetById([FromQuery] EducationInformationDetailQuery  educationInformationDetailQuery)
        {
            var response = await _mediator.Send(educationInformationDetailQuery);
            return Ok(response);
        }

        /// <summary>
        /// You can call it to the whole EducationInformation list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetList()
        {
            var response = await _mediator.Send(new EducationInformationListQuery());
            return Ok(response);
        }

        /// <summary>
        /// You can call it to the whole  EducationInformation list by User Id.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetListByUserId([FromQuery] EducationInformationListByUserIdQuery educationInformationListByUserIdQuery)
        {
            var response = await _mediator.Send(educationInformationListByUserIdQuery);
            return Ok(response);
        }

    }
}
