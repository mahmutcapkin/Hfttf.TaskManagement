using Hfttf.TaskManagement.API.Domain.Services;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.ResourceViewModel;
using Hfttf.TaskManagement.Service.Services.Users.Commands;
using Hfttf.TaskManagement.Service.Services.Users.Queries;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.API.Controllers
{
    
    [Route("api/TaskManagementApi/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMediator _mediator;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, IMediator mediator,ILogger<UsersController> logger)
        {
            this.userService = userService;
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> getUser()
        {
            ApplicationUser user = await userService.GetUserByUserName(User.Identity.Name);
            return Ok(user.Adapt<SignUpViewModelResource>());
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ActiveUser()
        {
           var response  = await userService.ActiveUserInfo(User.Identity.Name);
            return Ok(response);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserViewResponse userViewResponse)
        {
            var response = await userService.UpdateUser(userViewResponse, User.Identity.Name);
            if (response.Success)
            {
                return Ok(response.Extra);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInsertCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Insert([FromBody] UserInsertCommand  userInsertCommand)
        {
            var response = await _mediator.Send(userInsertCommand);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userUpdateCommand"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] UserUpdateCommand userUpdateCommand)
        {
            var response = await _mediator.Send(userUpdateCommand);
            return Ok(response);
        }

        /// <summary>
        /// You can use it to delete a User
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UserDeleteCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> Delete(string id)
        {
            var result = await _mediator.Send(new UserDeleteCommand() { Id=id});
            return Ok(result);
        }

        /// <summary>
        /// You can call it to the whole User list.
        /// </summary>
        /// <returns></returns>
        //[Authorize(Roles ="admin")]
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetList()
        {
            //var user = User.Identity.Name;
            var response = await _mediator.Send(new UserListQuery());
            return Ok(response);
        }

        /// <summary>
        /// You can call it to the whole User list.
        /// </summary>
        /// <returns></returns>
        //[Authorize(Roles ="admin")]
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetListWithInfo()
        {
            //var user = User.Identity.Name;
            var response = await _mediator.Send(new UserListWithInfoQuery());
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDetailQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetById([FromQuery] UserDetailQuery  userDetailQuery)
        {
            var response = await _mediator.Send(userDetailQuery);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDetailWithInfoQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetByIdWithInfo([FromQuery] UserDetailWithInfoQuery  userDetailWithInfoQuery)
        {
            var response = await _mediator.Send(userDetailWithInfoQuery);
            return Ok(response);
        }

        //[HttpPost]
        //public async Task<IActionResult> UploadUserPicture(IFormFile picture)
        //{
        //    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(picture.FileName);
        //    var path = Path.Combine(Directory.GetCurrentDirectory() + "wwwroot/UserPictures", fileName);
        //    using (var stream = new FileStream(path, FileMode.Create))
        //    {
        //        await picture.CopyToAsync(stream);
        //    }
        //    var result = new
        //    {
        //        path = "https://" + Request.Host + "/UserPictures" + fileName
        //    };

        //    var response = await userService.UploadUserPicture(result.path, User.Identity.Name);
        //    if (response.Success)
        //    {
        //        return Ok(path);
        //    }
        //    else
        //    {
        //        return BadRequest(response.Message);
        //    }
        //}


    }
}