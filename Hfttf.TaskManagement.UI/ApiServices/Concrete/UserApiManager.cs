using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;

namespace Hfttf.TaskManagement.UI.ApiServices.Concrete
{
    public class UserApiManager:IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserApiManager(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:61411/api/TaskManagementApi/Users/");
        }
    }
}
