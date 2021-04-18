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

        public async Task<List<LeaderList>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<LeaderList> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(LeaderUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
