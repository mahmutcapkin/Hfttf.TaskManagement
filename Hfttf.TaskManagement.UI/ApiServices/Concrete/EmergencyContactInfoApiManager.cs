using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models.EmergencyContactInfo;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Concrete
{
    public class EmergencyContactInfoApiManager:IEmergencyContactInfoService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmergencyContactInfoApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddAsync(EmergencyContactInfoAdd model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmergencyContactUserInfoResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<EmergencyContactUserInfoResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmergencyContactUserInfoResponse>> GetListByUserId(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(EmergencyContactInfoUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
