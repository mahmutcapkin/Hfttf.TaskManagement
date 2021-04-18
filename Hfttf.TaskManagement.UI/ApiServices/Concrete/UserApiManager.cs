using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;

namespace Hfttf.TaskManagement.UI.ApiServices.Concrete
{
    public class UserApiManager:IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
