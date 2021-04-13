using Hfttf.TaskManagement.API.Domain.Responses;
using Hfttf.TaskManagement.API.Domain.Services;
using Hfttf.TaskManagement.Core.ResourceViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.API.Controllers
{
    [Route("api/TaskManagementApi/[controller]/[action]")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationsController(IAuthenticationService service)
        {
            this.authenticationService = service;
        }

        //localhost:33444/api/ Authentication/IsAuthenticatin
        [HttpGet]
        public ActionResult IsAuthentication()
        {
            return Ok(User.Identity.IsAuthenticated);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody]SignUpViewModelResource userViewModelResource)
        {

            BaseResponse<SignUpViewModelResource> response = await this.authenticationService.SignUp(userViewModelResource);
            if (response.Success)
            {
                return Ok(response.Extra);
            }
            else
            {
                return BadRequest(response.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody]SignInViewModelResource signInViewModel)
        {

            var response = await authenticationService.SignIn(signInViewModel);

            if (response.Success)
            {
                return Ok(response.Extra);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateAccessTokenByRefreshToken(RefreshTokenViewModelResource refreshTokenView)
        {

            var response = await authenticationService.CreateAccessTokenByRefreshToken(refreshTokenView);
            if (response.Success)
            {
                return Ok(response.Extra);
            }
            else
            {
                return BadRequest(response.Message);
            }

        }

        [HttpDelete]
        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenViewModelResource refreshTokenView)
        {
            var response = await authenticationService.RevokeRefreshToken(refreshTokenView);
            if (response.Success)
            {
                return Ok();
            }
            else
            {
                return BadRequest(response.Message);
            }

        }


    }
}