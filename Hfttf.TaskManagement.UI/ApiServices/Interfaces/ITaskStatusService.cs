using Hfttf.TaskManagement.UI.Models.TaskStatus;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface ITaskStatusService
    {
        Task<List<TaskStatusResponse>> GetAllAsync();
        Task<TaskStatusResponse> GetByIdAsync(int id);
        Task<bool> AddAsync(TaskStatusAdd model);
        Task<bool> UpdateAsync(TaskStatusUpdate model);
        Task<bool> DeleteAsync(int id);
        Task<List<TaskStatusResponse>> GetListWithTasks(int id);
        Task<TaskStatusResponse> GetTaskStatusWithTasksByStatusId(int id);
    }
}
