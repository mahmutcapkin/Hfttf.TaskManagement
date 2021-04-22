using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Service.Services.TaskStatuses.Commands;
using Hfttf.TaskManagement.Service.Services.TaskStatuses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
        /// You can use it to update a TaskStatus
        /// </summary>
        /// <param name="taskStatusUpdateCommand">Hello World</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(TaskStatusUpdateCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Update([FromBody] TaskStatusUpdateCommand  taskStatusUpdateCommand)
        {
            if (taskStatusUpdateCommand is null)
            {
                throw new ArgumentNullException(nameof(taskStatusUpdateCommand));
            }

            var result = await _mediator.Send(taskStatusUpdateCommand);
            return Ok(result);
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
        /// 
        /// </summary>
        /// <param name="taskStatusDetailQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetById([FromQuery] TaskStatusDetailQuery  taskStatusDetailQuery)
        {
            var response = await _mediator.Send(taskStatusDetailQuery);
            return Ok(response);
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
        /// You can call it to the whole Task Status list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetListWithTasks()
        {
            var response = await _mediator.Send(new TaskStatusListWithTasksQuery());
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskStatusWithTasksByStatusIdQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetTaskStatusWithTasksByStatusId([FromQuery] TaskStatusWithTasksByStatusIdQuery  taskStatusWithTasksByStatusIdQuery)
        {
            var response = await _mediator.Send(taskStatusWithTasksByStatusIdQuery);
            return Ok(response);
        }
    }
}
