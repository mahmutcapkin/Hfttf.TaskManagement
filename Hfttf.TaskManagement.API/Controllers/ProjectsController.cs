﻿using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Service.Services.Projects.Commands;
using Hfttf.TaskManagement.Service.Services.Projects.Queries;
using Hfttf.TaskManagement.Service.Services.Projects.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Izersoft.TaskManagement.API.Controllers
{
    [Route("api/TaskManagementApi/[controller]/[action]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProjectsController> _logger;

        public ProjectsController(IMediator mediator, ILogger<ProjectsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectInsertCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ProjectInsertCommand), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Response>> Insert([FromBody] ProjectInsertCommand projectInsertCommand)
        {
            var response = await _mediator.Send(projectInsertCommand);
            return Ok(response);
        }



        /// <summary>
        /// You can use it to update a project.
        /// </summary>
        /// <param name="projectUpdateCommand">Hello World</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ProjectUpdateCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Update([FromBody] ProjectUpdateCommand projectUpdateCommand)
        {
            var result = await _mediator.Send(projectUpdateCommand);
            return Ok(result);
        }

        /// <summary>
        /// You can use it to delete a project.
        /// </summary>
        /// <param name="projectDeleteCommand">Hello World</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(ProjectDeleteCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Delete([FromBody] ProjectDeleteCommand projectDeleteCommand)
        {
            var result = await _mediator.Send(projectDeleteCommand);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectDetailQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetById([FromQuery] ProjectDetailQuery projectDetailQuery)
        {
            var response = await _mediator.Send(projectDetailQuery);
            return Ok(response);
        }

        /// <summary>
        /// You can call it to the whole project list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetList()
        {
            var response = await _mediator.Send(new ProjectListQuery());
            return Ok(response);
        }


        /// <summary>
        /// You can call it to the whole project pagination list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProjectResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProjectResponse>>> GetListPagination([FromQuery] ProjectListPaginationQuery projectListPaginationQuery)
        {
            projectListPaginationQuery.SetRoute(Request.Path.Value);
            var projectResponses = await _mediator.Send(projectListPaginationQuery);
            return Ok(projectResponses);
        }


        /// <summary>
        /// You can call it to the whole project list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetProjectsByUserId(string id)
        {
            var response = await _mediator.Send(new ProjectListByUserIdQuery() { Id = id });
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectFileUploadCommand"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> UploadProjectProfile([FromQuery] ProjectFileUploadCommand projectFileUploadCommand)
        {
            var response = await _mediator.Send(projectFileUploadCommand);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectListPaginationByUserIdQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> ListPaginationByUserId([FromQuery] ProjectListPaginationByUserIdQuery projectListPaginationByUserIdQuery)
        {
            var response = await _mediator.Send(projectListPaginationByUserIdQuery);
            return Ok(response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectGetProjectDetailByIdQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetProjectDetailById([FromQuery] ProjectGetProjectDetailByIdQuery projectGetProjectDetailByIdQuery)
        {
            var response = await _mediator.Send(projectGetProjectDetailByIdQuery);
            return Ok(response);
        }
    }
}
