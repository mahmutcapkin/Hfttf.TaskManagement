using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models.EducationInformation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Concrete
{
    public class EducationInformationApiManager:IEducationInformationService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EducationInformationApiManager(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:61411/api/TaskManagementApi/EducationInformations/");
        }

        public async Task AddAsync(EducationInformationAdd model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EducationInformationList>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<EducationInformationList> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(EducationInformationUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
