using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Extensions;
using Hfttf.TaskManagement.UI.Models;
using Hfttf.TaskManagement.UI.Models.Authentication;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Concrete
{
    public class AuthApiManager : IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> SignIn(SignInViewModel signInViewModel)
        {
            var jsonData = JsonConvert.SerializeObject(signInViewModel);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            using var httpClient = new HttpClient();
            var responseMessage = await httpClient.PostAsync("http://localhost:5000/api/TaskManagementApi/Authentications/SignIn", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                var accessToken = JsonConvert.DeserializeObject<AccessToken>(await responseMessage.Content.ReadAsStringAsync());

                _httpContextAccessor.HttpContext.Session.SetString("token", accessToken.Token);
                _httpContextAccessor.HttpContext.Session.SetString("refreshtoken", accessToken.RefreshToken);

                return true;
            }
            return false;
        }

        public async Task<bool> SignUp(SignUpViewModel signUpViewModel)
        {
            var jsonData = JsonConvert.SerializeObject(signUpViewModel);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            using var httpClient = new HttpClient();
            var responseMessage = await httpClient.PostAsync("http://localhost:5000/api/TaskManagementApi/Authentications/SignUp", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                var accessToken = JsonConvert.DeserializeObject<AccessToken>(await responseMessage.Content.ReadAsStringAsync());
               // _httpContextAccessor.HttpContext.Session.SetString("token", accessToken.Token);

                return true;
            }
            return false;
        }

        public async Task<HttpResponseMessage> GetActiveUser(string token)
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await httpClient.GetAsync("http://localhost:5000/api/TaskManagementApi/Users/ActiveUser");
        }

        public async Task LogOut()
        {
            _httpContextAccessor.HttpContext.Session.Remove("token");
            _httpContextAccessor.HttpContext.Session.Remove("activeUser");
        }

        public async Task<AppUser> ActiveUser(string token)
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var responseMessage = await httpClient.GetAsync("http://localhost:5000/api/TaskManagementApi/Users/ActiveUser");
            AppUser activeUser = new AppUser();
            if (responseMessage.IsSuccessStatusCode)
            {
                activeUser = JsonConvert.DeserializeObject<AppUser>(await responseMessage.Content.ReadAsStringAsync());
               // _httpContextAccessor.HttpContext.Session.SetObject("activeUser", activeUser);
            }
            return activeUser;
        }
    }
}