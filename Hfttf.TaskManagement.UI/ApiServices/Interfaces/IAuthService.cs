using Hfttf.TaskManagement.UI.Models.Authentication;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface IAuthService
    {
        Task<bool> SignIn(SignInViewModel signInViewModel);
        Task<bool> SignUp(SignUpViewModel signUpViewModel);
        Task<HttpResponseMessage> GetActiveUser(string token);
        Task<AppUser> ActiveUser(string token);
        Task LogOut();
    }
}