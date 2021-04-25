using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Concrete
{
    public class UserApiManager:IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Task AddAsync(UserAdd model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserList>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserList> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<UserList> GetByIdWithInfo(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserList>> GetListWithInfo(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
