using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models.UserSalary;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Concrete
{
    public class UserSalaryApiManager:IUserSalaryService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserSalaryApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddAsync(UserSalaryAdd model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserSalaryForUserInfoResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserSalaryForUserInfoResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserSalaryForUserInfoResponse>> GetListByUserId(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(UserSalaryUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
