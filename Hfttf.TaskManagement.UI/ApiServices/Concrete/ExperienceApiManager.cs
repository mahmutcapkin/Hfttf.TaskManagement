using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models.Experience;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Concrete
{
    public class ExperienceApiManager:IExperienceService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExperienceApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddAsync(ExperienceAdd model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ExperienceForUserInfoResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ExperienceForUserInfoResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ExperienceForUserInfoResponse>> GetListByUserId(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(ExperienceUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
