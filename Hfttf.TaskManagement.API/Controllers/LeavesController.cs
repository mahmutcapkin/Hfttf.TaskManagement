using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Service.Services.Leaves.Commands;
using Hfttf.TaskManagement.Service.Services.Leaves.Queries;
using Hfttf.TaskManagement.Service.Services.Leaves.Responses;
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
    public class LeavesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LeavesController> _logger;

        public LeavesController(IMediator mediator, ILogger<LeavesController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// You can use it to instert a Leave.
        /// </summary>
        /// <param name="leaveInsertCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(LeaveInsertCommand), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Response>> Insert([FromBody] LeaveInsertCommand leaveInsertCommand)
        {
            var response = await _mediator.Send(leaveInsertCommand);
            return Ok(response);
        }

        /// <summary>
        /// You can use it to update a Leave Assign.
        /// </summary>
        /// <param name="leaveUpdateCommand">Hello World</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(LeaveUpdateCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Update([FromBody] LeaveUpdateCommand leaveUpdateCommand)
        {
            var result = await _mediator.Send(leaveUpdateCommand);
            return Ok(result);
        }

        /// <summary>
        /// You can use it to delete a Leave
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(LeaveDeleteCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            var result = await _mediator.Send(new LeaveDeleteCommand() { Id = id });
            return Ok(result);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveDetailQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetById([FromQuery] LeaveDetailQuery leaveDetailQuery)
        {
            var response = await _mediator.Send(leaveDetailQuery);
            return Ok(response);
        }

        /// <summary>
        /// You can call it to the whole Leave list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetList()
        {
            var response = await _mediator.Send(new LeaveListQuery());
            return Ok(response);
        }


        /// <summary>
        /// You can call it to the whole Leave pagination list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LeaveResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<LeaveResponse>>> GetListPagination([FromQuery] LeaveListPaginationQuery leaveListPaginationQuery)
        {
            leaveListPaginationQuery.SetRoute(Request.Path.Value);
            var LeaveResponses = await _mediator.Send(leaveListPaginationQuery);
            return Ok(LeaveResponses);
        }

        /// <summary>
        /// You can call it to the whole  Leave list by User Id.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetListByUserId([FromQuery] LeaveListByUserIdQuery  leaveListByUserIdQuery)
        {
            var response = await _mediator.Send(leaveListByUserIdQuery);
            return Ok(response);
        }

    }
}
