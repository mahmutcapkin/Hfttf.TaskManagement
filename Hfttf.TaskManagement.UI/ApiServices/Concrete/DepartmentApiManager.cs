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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DepartmentApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddAsync(DepartmentAdd model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DepartmentForUserResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<DepartmentForUserResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentResponse> GetDepartmentWithUsersById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DepartmentForUserResponse>> GetListWithUsers()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(DepartmentUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
