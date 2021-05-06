using Hfttf.TaskManagement.UI.Models.Task;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskResponse>> GetAllAsync();
        Task<TaskResponse> GetByIdAsync(int id);
        Task<bool> AddAsync(TaskAdd model);
        Task<bool> UpdateAsync(TaskUpdate model);
        Task<bool> DeleteAsync(int id);
        Task<List<TaskResponse>> GetListByProjectId(int id);
        Task<List<TaskResponse>> GetListByStatusId(int id);
        Task<TaskResponse> GetByIdWithProjectandStatus(int id);
    }
}
