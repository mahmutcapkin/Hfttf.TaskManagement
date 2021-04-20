using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Service.Services.TaskStatuses.Commands;
using Hfttf.TaskManagement.Service.Services.TaskStatuses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace Izersoft.TaskManagement.API.Controllers
{
    [Route("api/TaskManagementApi/[controller]/[action]")]
    [ApiController]
    public class TaskStatusesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TaskStatusesController> _logger;

        public TaskStatusesController(IMediator mediator, ILogger<TaskStatusesController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskStatusInsertCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(TaskStatusInsertCommand), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Response>> Insert([FromBody] TaskStatusInsertCommand taskStatusInsertCommand)
        {
            var response = await _mediator.Send(taskStatusInsertCommand);
            return Ok(response);
        }

        /// <summary>
        /// You can use it to delete a task status.
        /// </summary>
        /// <param name="taskStatusDeleteCommand">Hello World</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(TaskStatusDeleteCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Delete([FromBody] TaskStatusDeleteCommand taskStatusDeleteCommand)
        {
            var result = await _mediator.Send(taskStatusDeleteCommand);
            return Ok(result);
        }


        /// <summary>
        /// You can call it to the whole Task Status list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetList()
        {
            var response = await _mediator.Send(new TaskStatusListQuery());
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskStatusListWithTasksByStatusIdQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetTaskStatusWithTasksByStatusId([FromQuery] TaskStatusListWithTasksByStatusIdQuery  taskStatusListWithTasksByStatusIdQuery)
        {
            var response = await _mediator.Send(taskStatusListWithTasksByStatusIdQuery);
            return Ok(response);
        }
    }
}
