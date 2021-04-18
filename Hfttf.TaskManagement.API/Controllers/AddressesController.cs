using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.ResourceViewModel;
using Hfttf.TaskManagement.Service.Services.Addresses.Commands;
using Hfttf.TaskManagement.Service.Services.Addresses.Queries;
using Hfttf.TaskManagement.Service.Services.Addresses.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.API.Controllers
{
    /// <summary>
    /// Address Controller
    /// </summary>
    [Route("api/TaskManagementApi/[controller]/[action]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AddressesController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="logger"></param>
        public AddressesController(IMediator mediator, ILogger<AddressesController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addressInsertCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(AddressInsertCommand), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Response>> Insert([FromBody] AddressInsertCommand addressInsertCommand)
        {
            if (addressInsertCommand is null)
            {
                throw new System.ArgumentNullException(nameof(addressInsertCommand));
            }

            var response = await _mediator.Send(addressInsertCommand);
            return Ok(response);
        }

        /// <summary>
        /// You can use it to update a Address
        /// </summary>
        /// <param name="addressUpdateCommand">Hello World</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(AddressUpdateCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Update([FromBody] AddressUpdateCommand addressUpdateCommand)
        {
            if (addressUpdateCommand is null)
            {
                throw new ArgumentNullException(nameof(addressUpdateCommand));
            }

            var result = await _mediator.Send(addressUpdateCommand);
            return Ok(result);
        }

        /// <summary>
        /// You can use it to delete a Address
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(AddressDeleteCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            var result = await _mediator.Send(new AddressDeleteCommand() { Id=id });
            return Ok(result);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="addressDetailQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetById([FromQuery] AddressDetailQuery addressDetailQuery)
        {
            var response = await _mediator.Send(addressDetailQuery);
            return Ok(response);
        }

        /// <summary>
        /// You can call it to the whole Address list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = UserRoles.User)]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetList()
        {
            var response = await _mediator.Send(new AddressListQuery());
            return Ok(response);
        }


        /// <summary>
        /// You can call it to the whole Address  pagination list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AddressResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<AddressResponse>>> GetListPagination([FromQuery] AddressListPaginationQuery addressListPaginationQuery)
        {
            addressListPaginationQuery.SetRoute(Request.Path.Value);
            var addressResponses = await _mediator.Send(addressListPaginationQuery);
            return Ok(addressResponses);
        }
    }
}
