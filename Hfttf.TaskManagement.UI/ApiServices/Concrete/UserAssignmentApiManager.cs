using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models.UserAssignment;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Concrete
{
    public class UserAssignmentApiManager:IUserAssignmentService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAssignmentApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddAsync(UserAssignmentAdd model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserAssignmentForUserResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserAssignmentForUserResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserAssignmentForUserResponse>> GetListByUserId(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(UserAssignmentUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
