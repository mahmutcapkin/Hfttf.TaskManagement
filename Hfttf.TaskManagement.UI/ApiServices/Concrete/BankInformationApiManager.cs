using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models.BankInformation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Concrete
{
    public class BankInformationApiManager:IBankInformationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BankInformationApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddAsync(BankInformationAdd model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BankInformationList>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<BankInformationList> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BankInformationList>> GetListByUserId(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(BankInformationUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
