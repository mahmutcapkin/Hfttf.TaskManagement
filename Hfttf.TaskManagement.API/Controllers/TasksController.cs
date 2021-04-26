using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Service.Services.Tasks.Commands;
using Hfttf.TaskManagement.Service.Services.Tasks.Queries;
using Hfttf.TaskManagement.Service.Services.Tasks.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Izersoft.TaskManagement.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/TaskManagementApi/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TasksController> _logger;

        public TasksController(IMediator mediator, ILogger<TasksController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskInsertCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(TaskInsertCommand), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Response>> Insert([FromBody] TaskInsertCommand taskInsertCommand)
        {
            var response = await _mediator.Send(taskInsertCommand);
            return Ok(response);
        }

        /// <summary>
        /// You can use it to update a task.
        /// </summary>
        /// <param name="taskUpdateCommand">Hello World</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(TaskUpdateCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Update([FromBody] TaskUpdateCommand taskUpdateCommand)
        {
            var result = await _mediator.Send(taskUpdateCommand);
            return Ok(result);
        }

        /// <summary>
        /// You can use it to delete a Task
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TaskDeleteCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            var result = await _mediator.Send(new TaskDeleteCommand() { Id = id });
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskDetailQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetById([FromQuery] TaskDetailQuery taskDetailQuery)
        {
            var response = await _mediator.Send(taskDetailQuery);
            return Ok(response);
        }


        /// <summary>
        /// You can call it to the whole task list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetList()
        {
            var response = await _mediator.Send(new TaskListQuery());
            return Ok(response);
        }


        /// <summary>
        /// You can call it to the whole task pagination list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TaskResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TaskResponse>>> GetListPagination([FromQuery] TaskListPaginationQuery taskListPaginationQuery)
        {
            taskListPaginationQuery.SetRoute(Request.Path.Value);
            var taskResponses = await _mediator.Send(taskListPaginationQuery);
            return Ok(taskResponses);
        }

      
        /// <summary>
        /// You can call it to the whole task pagination list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TaskResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TaskResponse>>> GetListByProjectIdPagination([FromQuery] TaskListByProjectIdPaginationQuery taskListByProjectIdPaginationQuery)
        {
            taskListByProjectIdPaginationQuery.SetRoute(Request.Path.Value);
            taskListByProjectIdPaginationQuery.ProjectId = taskListByProjectIdPaginationQuery.ProjectId;
            var taskResponses = await _mediator.Send(taskListByProjectIdPaginationQuery);
            return Ok(taskResponses);
        }

        /// <summary>
        /// You can call it to the whole  Task list by Project Id.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetListByProjectId([FromQuery] TaskListByProjectIdQuery taskListByProjectIdQuery)
        {
            var response = await _mediator.Send(taskListByProjectIdQuery);
            return Ok(response);
        }

        /// <summary>
        /// You can call it to the whole  Task list by Status Id.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetListByStatusId([FromQuery] TaskListByStatusIdQuery taskListByStatusIdQuery)
        {
            var response = await _mediator.Send(taskListByStatusIdQuery);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskDetailWithProjectAndStatusQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetByIdWithProjectandStatus([FromQuery] TaskDetailWithProjectAndStatusQuery  taskDetailWithProjectAndStatusQuery)
        {
            var response = await _mediator.Send(taskDetailWithProjectAndStatusQuery);
            return Ok(response);
        }

        ///// <summary>
        ///// You can call it to the whole task list by projectId.
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //[ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        //public async Task<ActionResult<Response>> GetListByProjectId(int id)
        //{
        //    var response = await _mediator.Send(new TaskListByProjectIdQuery() { ProjectId = id });
        //    return Ok(response);
        //}
    }
}

