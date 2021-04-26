using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models.Leader;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Concrete
{
    public class LeaderApiManager:ILeaderService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public LeaderApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddAsync(LeaderAdd model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LeaderForUserResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<LeaderForUserResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LeaderForUserResponse> GetByIdWithProjectAndUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LeaderForUserResponse> GetByProjectIdandUserId(int projectId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<LeaderForUserResponse>> GetListByProjectId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LeaderForUserResponse>> GetListByProjectIdandUserId(int projectId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<LeaderForUserResponse>> GetListByUserId(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(LeaderUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
