using Hfttf.TaskManagement.API.Domain.Services;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.ResourceViewModel;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.API.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [Route("api/TaskManagementApi/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]

        public async Task<IActionResult> getUser()
        {
            ApplicationUser user = await userService.GetUserByUserName(User.Identity.Name);
            return Ok(user.Adapt<SignUpViewModelResource>());
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