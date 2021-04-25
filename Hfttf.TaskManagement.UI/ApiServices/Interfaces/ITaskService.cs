using Hfttf.TaskManagement.UI.Models.Task;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskList>> GetAllAsync();
        Task<TaskList> GetByIdAsync(int id);
        Task AddAsync(TaskAdd model);
        Task UpdateAsync(TaskUpdate model);
        Task DeleteAsync(int id);
        Task<List<TaskList>> GetListByProjectId(int id);
        Task<List<TaskList>> GetListByStatusId(int id);
        Task<TaskList> GetByIdWithProjectandStatus(int id);
    }
}
