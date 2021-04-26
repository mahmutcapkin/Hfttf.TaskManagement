using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models.Task;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Concrete
{
    public class TaskApiManager:ITaskService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TaskApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddAsync(TaskAdd model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TaskForUserAssignmentResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TaskForUserAssignmentResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TaskForUserAssignmentResponse> GetByIdWithProjectandStatus(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TaskForUserAssignmentResponse>> GetListByProjectId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TaskForUserAssignmentResponse>> GetListByStatusId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(TaskUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
