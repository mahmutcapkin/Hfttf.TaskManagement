using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models.Holiday;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Concrete
{
    public class HolidayApiManager:IHolidayService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HolidayApiManager( IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;;
        }

        public async Task AddAsync(HolidayAdd model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<HolidayList>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<HolidayList> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(HolidayUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
