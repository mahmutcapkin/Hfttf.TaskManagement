using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Service.Services.Roles.Commands;
using Hfttf.TaskManagement.Service.Services.Roles.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/TaskManagementApi/[controller]/[action]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;
        private readonly ILogger<RolesController> _logger;

        public RolesController(
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IMediator mediator,
            ILogger<RolesController> logger
            )
        {
            _mediator = mediator;
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        //[HttpGet]
        //public async Task<IActionResult> ResetUserPassword(string id)
        //{
        //    ApplicationUser user = await _userManager.FindByIdAsync(id);
        //    ResetPasswordByAdminViewModel passwordResetByAdminViewModel = new ResetPasswordByAdminViewModel();
        //    passwordResetByAdminViewModel.UserId = user.Id;
        //    return Ok(passwordResetByAdminViewModel);
        //}

        //[HttpPost]
        //public async Task<IActionResult> ResetUserPassword(ResetPasswordByAdminViewModel resetPasswordByAdminViewModel)
        //{
        //    ApplicationUser user = await _userManager.FindByIdAsync(resetPasswordByAdminViewModel.UserId);

        //    string token = await _userManager.GeneratePasswordResetTokenAsync(user);

        //    IdentityResult identityResult = await _userManager.ResetPasswordAsync(user, token, resetPasswordByAdminViewModel.NewPassword);
        //    if (identityResult.Succeeded)
        //    {
        //        await _userManager.UpdateSecurityStampAsync(user);
        //        return Ok(identityResult.Succeeded);
        //    }
        //    return BadRequest(identityResult.Errors);
        //}

        /// <summary>
        /// You can use it to instert a role
        /// </summary>
        /// <param name="roleInsertCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(RoleInsertCommand), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Response>> Insert([FromBody] RoleInsertCommand roleInsertCommand)
        {
            var response = await _mediator.Send(roleInsertCommand);
            return Ok(response);
        }

        /// <summary>
        /// You can use it to update a role
        /// </summary>
        /// <param name="roleUpdateCommand">Hello World</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(RoleUpdateCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Update([FromBody] RoleUpdateCommand roleUpdateCommand)
        {
            var result = await _mediator.Send(roleUpdateCommand);
            return Ok(result);
        }

        /// <summary>
        /// You can use it to delete a role
        /// </summary>
        /// <param name="roleDeleteCommand">Hello World</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(RoleDeleteCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Delete([FromBody] RoleDeleteCommand roleDeleteCommand)
        {
            var result = await _mediator.Send(roleDeleteCommand);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleDetailQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetById([FromQuery] RoleDetailQuery  roleDetailQuery)
        {
            var response = await _mediator.Send(roleDetailQuery);
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
            var response = await _mediator.Send(new RoleListQuery());
            return Ok(response);
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="roleGetUserRolesQuery"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        //public async Task<ActionResult<Response>> GetUserRoles([FromQuery] RoleGetUserRolesQuery roleGetUserRolesQuery)
        //{
        //    var response = await _mediator.Send(roleGetUserRolesQuery);
        //    return Ok(response);
        //}

        /// <summary>
        /// You can use it to assign a role to user
        /// </summary>
        /// <param name="roleAssignRoleToUserCommand">Hello World</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(RoleAssignRoleToUserCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> AssignRoleToUser([FromBody] RoleAssignRoleToUserCommand roleAssignRoleToUserCommand)
        {
            var result = await _mediator.Send(roleAssignRoleToUserCommand);
            return Ok(result);
        }

        /// <summary>
        /// You can use it to delete a role to user
        /// </summary>
        /// <param name="roleDeleteRoleToUserCommand">Hello World</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(RoleAssignRoleToUserCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> DeleteRoleToUser([FromBody] RoleDeleteRoleToUserCommand  roleDeleteRoleToUserCommand)
        {
            var result = await _mediator.Send(roleDeleteRoleToUserCommand);
            return Ok(result);
        }

    }
}
