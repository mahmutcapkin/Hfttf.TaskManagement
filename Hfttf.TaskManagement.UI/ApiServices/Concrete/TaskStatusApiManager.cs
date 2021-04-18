using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models.TaskStatus;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Concrete
{
    public class TaskStatusApiManager:ITaskStatusService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TaskStatusApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddAsync(TaskStatusAdd model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TaskStatusList>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TaskStatusList> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(TaskStatusUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
