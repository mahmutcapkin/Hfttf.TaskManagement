using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Service.Services.Holidays.Commands;
using Hfttf.TaskManagement.Service.Services.Holidays.Queries;
using Hfttf.TaskManagement.Service.Services.Holidays.Responses;
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
    public class HolidaysController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<HolidaysController> _logger;

        public HolidaysController(IMediator mediator, ILogger<HolidaysController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// You can use it to instert a Holiday.
        /// </summary>
        /// <param name="holidayInsertCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(HolidayInsertCommand), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Response>> Insert([FromBody] HolidayInsertCommand holidayInsertCommand)
        {
            var response = await _mediator.Send(holidayInsertCommand);
            return Ok(response);
        }

        /// <summary>
        /// You can use it to update a Holiday Assign.
        /// </summary>
        /// <param name="holidayUpdateCommand">Hello World</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(HolidayUpdateCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Update([FromBody] HolidayUpdateCommand holidayUpdateCommand)
        {
            var result = await _mediator.Send(holidayUpdateCommand);
            return Ok(result);
        }

        /// <summary>
        /// You can use it to delete a Holiday Assign.
        /// </summary>
        /// <param name="holidayDeleteCommand">Hello World</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(HolidayDeleteCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Delete([FromBody] HolidayDeleteCommand holidayDeleteCommand)
        {
            var result = await _mediator.Send(holidayDeleteCommand);
            return Ok(result);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="holidayDetailQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetById([FromQuery] HolidayDetailQuery holidayDetailQuery)
        {
            var response = await _mediator.Send(holidayDetailQuery);
            return Ok(response);
        }

        /// <summary>
        /// You can call it to the whole Holiday list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetList()
        {
            var response = await _mediator.Send(new HolidayListQuery());
            return Ok(response);
        }


        /// <summary>
        /// You can call it to the whole Holiday pagination list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<HolidayResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<HolidayResponse>>> GetListPagination([FromQuery] HolidayListPaginationQuery holidayListPaginationQuery)
        {
            holidayListPaginationQuery.SetRoute(Request.Path.Value);
            var holidayResponses = await _mediator.Send(holidayListPaginationQuery);
            return Ok(holidayResponses);
        }

    }
}
