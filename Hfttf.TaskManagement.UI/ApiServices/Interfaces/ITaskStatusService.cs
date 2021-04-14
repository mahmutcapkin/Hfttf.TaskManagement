using Hfttf.TaskManagement.UI.Models.TaskStatus;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface ITaskStatusService
    {
        Task<List<TaskStatusList>> GetAllAsync();
        Task<TaskStatusList> GetByIdAsync(int id);
        Task AddAsync(TaskStatusAdd model);
        Task UpdateAsync(TaskStatusUpdate model);
        Task DeleteAsync(int id);
    }
}
