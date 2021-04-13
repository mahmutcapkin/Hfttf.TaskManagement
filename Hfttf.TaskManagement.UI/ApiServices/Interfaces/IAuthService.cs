using Hfttf.TaskManagement.UI.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface IAuthApiService
    {
        Task<bool> SignIn(SignInViewModel  signInViewModel);
        Task<bool> SignUp(SignUpViewModel signUpViewModel);
        Task<HttpResponseMessage> GetActiveUser(string token);
        void LogOut();
    }
}