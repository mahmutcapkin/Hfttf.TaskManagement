using Hfttf.TaskManagement.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = Hfttf.TaskManagement.Core.Entities.Task;

namespace Hfttf.TaskManagement.Core.Repositories
{
    public interface ITaskRepository : IRepository<Task>
    {
        Task<IReadOnlyList<Task>> GetListByProjectId(int? projectId);
        Task<IReadOnlyList<Task>> GetListByTaskStatusId(int taskStatusId);
        Task<IReadOnlyList<Task>> GetListWithStatusAndProject();
        Task<Task> GetTaskWithStatusAndProject(int id);
        Task<IReadOnlyList<Task>> GetListByProjectIdPagination(int projectId, int pageNumber, int pageSize);
    }
}
