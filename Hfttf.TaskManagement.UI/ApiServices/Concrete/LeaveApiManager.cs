using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models.Holiday;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Concrete
{
    public class LeaveApiManager:ILeaveService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LeaveApiManager( IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;;
        }

        public async Task AddAsync(LeaveAdd model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LeaveForUserResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<LeaveForUserResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LeaveForUserResponse>> GetListByUserId(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(LeaveUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
