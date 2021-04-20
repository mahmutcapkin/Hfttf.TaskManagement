﻿using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Commands;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Queries;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Responses;
using MediatR;
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
    public class UserAssignmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserAssignmentController> _logger;

        public UserAssignmentController(IMediator mediator, ILogger<UserAssignmentController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userAssignmentInsertCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(UserAssignmentInsertCommand), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Response>> Insert([FromBody] UserAssignmentInsertCommand userAssignmentInsertCommand)
        {
            if (userAssignmentInsertCommand is null)
            {
                throw new System.ArgumentNullException(nameof(userAssignmentInsertCommand));
            }

            var response = await _mediator.Send(userAssignmentInsertCommand);
            return Ok(response);
        }

        /// <summary>
        /// You can use it to update a Task Assign.
        /// </summary>
        /// <param name="userAssignmentUpdateCommand">Hello World</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(UserAssignmentUpdateCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Update([FromBody] UserAssignmentUpdateCommand userAssignmentUpdateCommand)
        {
            var result = await _mediator.Send(userAssignmentUpdateCommand);
            return Ok(result);
        }

        /// <summary>
        /// You can use it to update a Task Assign.
        /// </summary>
        /// <param name="userAssignmentDeleteCommand">Hello World</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(UserAssignmentDeleteCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Delete([FromBody] UserAssignmentDeleteCommand userAssignmentDeleteCommand)
        {
            var result = await _mediator.Send(userAssignmentDeleteCommand);
            return Ok(result);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userAssignmentDetailQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetById([FromQuery] UserAssignmentDetailQuery userAssignmentDetailQuery)
        {
            var response = await _mediator.Send(userAssignmentDetailQuery);
            return Ok(response);
        }


        /// <summary>
        /// You can call it to the whole User Assign list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetList()
        {
            var response = await _mediator.Send(new UserAssignmentListQuery());
            return Ok(response);
        }


        /// <summary>
        /// You can call it to the whole User Assign  pagination list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserAssignmentResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<UserAssignmentResponse>>> GetListPagination([FromQuery] UserAssignmentListPaginationQuery userAssignmentListPaginationQuery)
        {
            userAssignmentListPaginationQuery.SetRoute(Request.Path.Value);
            var userAssignmentResponses = await _mediator.Send(userAssignmentListPaginationQuery);
            return Ok(userAssignmentResponses);
        }

        /// <summary>
        /// You can call it to the whole   User Assign list by User Id.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetListByUserId([FromQuery] UserAssignmentListByUserIdQuery  userAssignmentListByUserIdQuery)
        {
            var response = await _mediator.Send(userAssignmentListByUserIdQuery);
            return Ok(response);
        }
    }
}
