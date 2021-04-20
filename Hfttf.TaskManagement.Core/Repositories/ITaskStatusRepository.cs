using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskStatus = Hfttf.TaskManagement.Core.Entities.TaskStatus;

namespace Hfttf.TaskManagement.Core.Repositories
{
    public interface ITaskStatusRepository : IRepository<TaskStatus>
    {
        //Task<IReadOnlyList<TaskStatus>> GetTaskByProjectId();
        //Task<TaskStatus> GetTaskStatusWithTasksByStatusNameId(int id);
        Task<IReadOnlyList<TaskStatus>> GetTaskStatusesWithTasks();
        Task<IReadOnlyList<TaskStatus>> GetTaskStatusWithTasksByStatusId(StatusLevel statusLevel);
    }
}
