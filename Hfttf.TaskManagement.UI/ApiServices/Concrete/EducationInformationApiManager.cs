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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EducationInformationApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddAsync(EducationInformationAdd model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EducationInformationForUserInfoResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<EducationInformationForUserInfoResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<EducationInformationForUserInfoResponse>> GetListByUserId(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(EducationInformationUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
