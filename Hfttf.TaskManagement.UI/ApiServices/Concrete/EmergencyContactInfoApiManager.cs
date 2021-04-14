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
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmergencyContactInfoApiManager(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:61411/api/TaskManagementApi/EmergencyContactInfos/");
        }

        public async Task AddAsync(EmergencyContactInfoAdd model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmergencyContactInfoList>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<EmergencyContactInfoList> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(EmergencyContactInfoUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
