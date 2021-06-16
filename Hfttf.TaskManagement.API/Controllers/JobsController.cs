using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.ResourceViewModel;
using Hfttf.TaskManagement.Service.Services.Jobs.Commands;
using Hfttf.TaskManagement.Service.Services.Jobs.Queries;
using Hfttf.TaskManagement.Service.Services.Jobs.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Izersoft.IdentityServer.API.Controllers
{

    [Route("api/TaskManagementApi/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = UserRoles.User + "," + UserRoles.Admin)]
    public class JobsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<JobsController> _logger;

        /// <summary>
        /// /
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="logger"></param>
        public JobsController(IMediator mediator, ILogger<JobsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobInsertCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(JobInsertCommand), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Response>> Insert([FromBody] JobInsertCommand jobInsertCommand)
        {
            if (jobInsertCommand is null)
            {
                throw new System.ArgumentNullException(nameof(JobInsertCommand));
            }

            var response = await _mediator.Send(jobInsertCommand);
            return Ok(response);
        }

        /// <summary>
        /// You can use it to update a Job
        /// </summary>
        /// <param name="jobUpdateCommand">Hello World</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(JobUpdateCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Update([FromBody] JobUpdateCommand jobUpdateCommand)
        {
            if (jobUpdateCommand is null)
            {
                throw new ArgumentNullException(nameof(jobUpdateCommand));
            }

            var result = await _mediator.Send(jobUpdateCommand);
            return Ok(result);
        }

        /// <summary>
        /// You can use it to delete a Job
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(JobDeleteCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            var result = await _mediator.Send(new JobDeleteCommand() { Id = id });
            return Ok(result);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobDetailQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetById([FromQuery] JobDetailQuery jobDetailQuery)
        {
            var response = await _mediator.Send(jobDetailQuery);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobDetailWithUsersQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetJobWithUsersById([FromQuery] JobDetailWithUsersQuery  jobDetailWithUsersQuery)
        {
            var response = await _mediator.Send(jobDetailWithUsersQuery);
            return Ok(response);
        }

        /// <summary>
        /// You can call it to the whole Job list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetList()
        {
            var response = await _mediator.Send(new JobListQuery());
            return Ok(response);
        }

        /// <summary>
        /// You can call it to the whole Job list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetListWithUsers()
        {
            var response = await _mediator.Send(new JobListWithUsersQuery());
            return Ok(response);
        }
        

        /// <summary>
        /// You can call it to the whole Job  pagination list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<JobResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<JobResponse>>> GetListPagination([FromQuery] JobListPaginationQuery jobListPaginationQuery)
        {
            jobListPaginationQuery.SetRoute(Request.Path.Value);
            var JobResponses = await _mediator.Send(jobListPaginationQuery);
            return Ok(JobResponses);
        }
    }
}
