using Hfttf.TaskManagement.API.Domain.Responses;
using Hfttf.TaskManagement.API.Security.Token;
using Hfttf.TaskManagement.Core.ResourceViewModel;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.API.Domain.Services
{
    public interface IAuthenticationService
    {

        Task<BaseResponse<SignUpViewModelResource>> SignUp(SignUpViewModelResource userViewModel);

        Task<BaseResponse<AccessToken>> SignIn(SignInViewModelResource signInViewModel);

        Task<BaseResponse<AccessToken>> CreateAccessTokenByRefreshToken(RefreshTokenViewModelResource refreshTokenViewModel);

        Task<BaseResponse<AccessToken>> RevokeRefreshToken(RefreshTokenViewModelResource refreshTokenViewModel);




    }
}
