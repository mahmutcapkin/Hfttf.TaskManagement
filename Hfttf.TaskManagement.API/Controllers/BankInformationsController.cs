using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Service.Services.BankInformations.Commands;
using Hfttf.TaskManagement.Service.Services.BankInformations.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.API.Controllers
{
    [Route("api/TaskManagementApi/[controller]/[action]")]
    [ApiController]
    public class BankInformationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BankInformationsController> _logger;

        public BankInformationsController(IMediator mediator, ILogger<BankInformationsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// You can use it to instert a BankInformation.
        /// </summary>
        /// <param name="bankInformationInsertCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(BankInformationInsertCommand), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Response>> Insert([FromBody] BankInformationInsertCommand bankInformationInsertCommand)
        {
            var response = await _mediator.Send(bankInformationInsertCommand);
            return Ok(response);
        }

        /// <summary>
        /// You can use it to update a BankInformation Assign.
        /// </summary>
        /// <param name="bankInformationUpdateCommand">Hello World</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(BankInformationUpdateCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Update([FromBody] BankInformationUpdateCommand bankInformationUpdateCommand)
        {
            var result = await _mediator.Send(bankInformationUpdateCommand);
            return Ok(result);
        }

        /// <summary>
        /// You can use it to delete a BankInformation
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(BankInformationDeleteCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            var result = await _mediator.Send(new BankInformationDeleteCommand() { Id = id });
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bankInformationDetailQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetById([FromQuery] BankInformationDetailQuery  bankInformationDetailQuery)
        {
            var response = await _mediator.Send(bankInformationDetailQuery);
            return Ok(response);
        }

        /// <summary>
        /// You can call it to the whole BankInformation list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetList()
        {
            var response = await _mediator.Send(new BankInformationListQuery());
            return Ok(response);
        }

        /// <summary>
        /// You can call it to the whole  BankInformation list by User Id.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetListByUserId([FromQuery] BankInformationListByUserIdQuery bankInformationListByUserIdQuery)
        {
            var response = await _mediator.Send(bankInformationListByUserIdQuery);
            return Ok(response);
        }
    }
}
