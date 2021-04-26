using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Service.Services.Departments.Commands;
using Hfttf.TaskManagement.Service.Services.Departments.Queries;
using Hfttf.TaskManagement.Service.Services.Departments.Responses;
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
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DepartmentsController> _logger;

        public DepartmentsController(IMediator mediator, ILogger<DepartmentsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DepartmentInsertCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(DepartmentInsertCommand), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Response>> Insert([FromBody] DepartmentInsertCommand departmentInsertCommand)
        {
            if (departmentInsertCommand is null)
            {
                throw new System.ArgumentNullException(nameof(DepartmentInsertCommand));
            }

            var response = await _mediator.Send(departmentInsertCommand);
            return Ok(response);
        }

        /// <summary>
        /// You can use it to update a Department
        /// </summary>
        /// <param name="departmentUpdateCommand">Hello World</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(DepartmentUpdateCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Update([FromBody] DepartmentUpdateCommand departmentUpdateCommand)
        {
            var result = await _mediator.Send(departmentUpdateCommand);
            return Ok(result);
        }

        /// <summary>
        /// You can use it to delete a Department
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(DepartmentDeleteCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            var result = await _mediator.Send(new DepartmentDeleteCommand() { Id = id });
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentDetailQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetById([FromQuery] DepartmentDetailQuery departmentDetailQuery)
        {
            var response = await _mediator.Send(departmentDetailQuery);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentDetailWithUserQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetDepartmentWithUsersById([FromQuery] DepartmentDetailWithUserQuery  departmentDetailWithUserQuery)
        {
            var response = await _mediator.Send(departmentDetailWithUserQuery);
            return Ok(response);
        }

        /// <summary>
        /// You can call it to the whole Department list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetList()
        {
            var response = await _mediator.Send(new DepartmentListQuery());
            return Ok(response);
        }

        /// <summary>
        /// You can call it to the whole Department list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetListWithUsers()
        {
            var response = await _mediator.Send(new DepartmentListWithUsersQuery());
            return Ok(response);
        }


        /// <summary>
        /// You can call it to the whole Department  pagination list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DepartmentResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<DepartmentResponse>>> GetListPagination([FromQuery] DepartmentListPaginationQuery departmentResponseListPaginationQuery)
        {
            departmentResponseListPaginationQuery.SetRoute(Request.Path.Value);
            var departmentResponses = await _mediator.Send(departmentResponseListPaginationQuery);
            return Ok(departmentResponses);
        }
    }
}
