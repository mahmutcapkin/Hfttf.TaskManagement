using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models.Department;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Concrete
{
    public class DepartmentApiManager:IDepartmentService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DepartmentApiManager(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:61411/api/TaskManagementApi/Departments/");
        }

        public async Task AddAsync(DepartmentAdd model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DepartmentList>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<DepartmentList> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(DepartmentUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
