using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.ResourceViewModel;
using Hfttf.TaskManagement.Service.Services.UserSalaries.Commands;
using Hfttf.TaskManagement.Service.Services.UserSalaries.Queries;
using Hfttf.TaskManagement.Service.Services.UserSalaries.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Izersoft.TaskManagement.API.Controllers
{
    [Route("api/TaskManagementApi/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = UserRoles.User + "," + UserRoles.Admin)]
    public class UserSalariesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserSalariesController> _logger;

        public UserSalariesController(IMediator mediator, ILogger<UserSalariesController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserSalaryInsertCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(UserSalaryInsertCommand), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Response>> Insert([FromBody] UserSalaryInsertCommand userSalaryInsertCommand)
        {
            var response = await _mediator.Send(userSalaryInsertCommand);
            return Ok(response);
        }

        /// <summary>
        /// You can use it to update a User Salary.
        /// </summary>
        /// <param name="userSalaryUpdateCommand">Hello World</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(UserSalaryUpdateCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Update([FromBody] UserSalaryUpdateCommand userSalaryUpdateCommand)
        {
            var result = await _mediator.Send(userSalaryUpdateCommand);
            return Ok(result);
        }

        /// <summary>
        /// You can use it to delete a UserSalary
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UserSalaryDeleteCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            var result = await _mediator.Send(new UserSalaryDeleteCommand() { Id = id });
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserSalaryDetailQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetById([FromQuery] UserSalaryDetailQuery userSalaryDetailQuery)
        {
            var response = await _mediator.Send(userSalaryDetailQuery);
            return Ok(response);
        }


        /// <summary>
        /// You can call it to the whole task User Salary.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetList()
        {
            var response = await _mediator.Send(new UserSalaryListQuery());
            return Ok(response);
        }


        /// <summary>
        /// You can call it to the whole task pagination User Salary.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserSalaryResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<UserSalaryResponse>>> GetListPagination([FromQuery] UserSalaryListPaginationQuery userSalaryListPaginationQuery)
        {
            userSalaryListPaginationQuery.SetRoute(Request.Path.Value);
            var userSalaryResponses = await _mediator.Send(userSalaryListPaginationQuery);
            return Ok(userSalaryResponses);
        }

        /// <summary>
        /// You can call it to the whole   User Salary list by User Id.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetListByUserId([FromQuery] UserSalaryListByUserIdQuery  userSalaryListByUserIdQuery)
        {
            var response = await _mediator.Send(userSalaryListByUserIdQuery);
            return Ok(response);
        }

    }
}
