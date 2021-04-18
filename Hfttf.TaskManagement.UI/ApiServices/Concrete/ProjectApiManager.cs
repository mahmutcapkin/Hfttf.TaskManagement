using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models.Project;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Concrete
{
    public class ProjectApiManager:IProjectService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProjectApiManager( IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;       
        }

        public async Task AddAsync(ProjectAdd model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProjectList>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ProjectList> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(ProjectUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
