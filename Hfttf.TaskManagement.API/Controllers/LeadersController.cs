using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Service.Services.Leaders.Commands;
using Hfttf.TaskManagement.Service.Services.Leaders.Queries;
using Hfttf.TaskManagement.Service.Services.Leaders.Responses;
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
    public class LeadersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LeadersController> _logger;

        public LeadersController(IMediator mediator, ILogger<LeadersController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// You can use it to instert a Leader.
        /// </summary>
        /// <param name="leaderInsertCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(LeaderInsertCommand), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Response>> Insert([FromBody] LeaderInsertCommand leaderInsertCommand)
        {
            var response = await _mediator.Send(leaderInsertCommand);
            return Ok(response);
        }

        /// <summary>
        /// You can use it to update a Leader.
        /// </summary>
        /// <param name="leaderUpdateCommand">Hello World</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(LeaderUpdateCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Update([FromBody] LeaderUpdateCommand leaderUpdateCommand)
        {
            var result = await _mediator.Send(leaderUpdateCommand);
            return Ok(result);
        }

        /// <summary>
        /// You can use it to delete a Leader.
        /// </summary>
        /// <param name="leaderDeleteCommand">Hello World</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(LeaderDeleteCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Delete([FromBody] LeaderDeleteCommand leaderDeleteCommand)
        {
            var result = await _mediator.Send(leaderDeleteCommand);
            return Ok(result);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaderDetailQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetById([FromQuery] LeaderDetailQuery leaderDetailQuery)
        {
            var response = await _mediator.Send(leaderDetailQuery);
            return Ok(response);
        }

        /// <summary>
        /// You can call it to the whole Leader list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetList()
        {
            var response = await _mediator.Send(new LeaderListQuery());
            return Ok(response);
        }


        /// <summary>
        /// You can call it to the whole Leader pagination list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LeaderResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<LeaderResponse>>> GetListPagination([FromQuery] LeaderListPaginationQuery leaderListPaginationQuery)
        {
            leaderListPaginationQuery.SetRoute(Request.Path.Value);
            var LeaderResponses = await _mediator.Send(leaderListPaginationQuery);
            return Ok(LeaderResponses);
        }

    }
}
