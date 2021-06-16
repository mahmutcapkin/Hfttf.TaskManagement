using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.ResourceViewModel;
using Hfttf.TaskManagement.Service.Services.Experiences.Commands;
using Hfttf.TaskManagement.Service.Services.Experiences.Queries;
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
    public class ExperiencesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ExperiencesController> _logger;

        public ExperiencesController(IMediator mediator, ILogger<ExperiencesController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        /// <summary>
        /// You can use it to instert a Experience.
        /// </summary>
        /// <param name="experienceInsertCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ExperienceInsertCommand), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Response>> Insert([FromBody] ExperienceInsertCommand experienceInsertCommand)
        {
            var response = await _mediator.Send(experienceInsertCommand);
            return Ok(response);
        }

        /// <summary>
        /// You can use it to update a Experience Assign.
        /// </summary>
        /// <param name="experienceUpdateCommand">Hello World</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ExperienceUpdateCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Update([FromBody] ExperienceUpdateCommand experienceUpdateCommand)
        {
            var result = await _mediator.Send(experienceUpdateCommand);
            return Ok(result);
        }

        /// <summary>
        /// You can use it to delete a Experience
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ExperienceDeleteCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            var result = await _mediator.Send(new ExperienceDeleteCommand() { Id = id });
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="experienceDetailQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetById([FromQuery] ExperienceDetailQuery  experienceDetailQuery)
        {
            var response = await _mediator.Send(experienceDetailQuery);
            return Ok(response);
        }

        /// <summary>
        /// You can call it to the whole Experience list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetList()
        {
            var response = await _mediator.Send(new ExperienceListQuery());
            return Ok(response);
        }

        /// <summary>
        /// You can call it to the whole  Experience list by User Id.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetListByUserId([FromQuery] ExperienceListByUserIdQuery experienceListByUserIdQuery)
        {
            var response = await _mediator.Send(experienceListByUserIdQuery);
            return Ok(response);
        }

    }
}
