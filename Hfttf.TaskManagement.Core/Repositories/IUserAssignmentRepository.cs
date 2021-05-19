using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Core.Repositories
{
    public interface IUserAssignmentRepository : IRepository<UserAssignment>
    {
        Task<IReadOnlyList<UserAssignment>> GetListWithUserandTask();

        Task<UserAssignment> GetDetailWithUserandTask(int id);
        Task<IReadOnlyList<UserAssignment>> GetListWithUserandTaskByUserId(string userId);

        Task<IReadOnlyList<UserAssignment>> GetListWithUserandTaskByProjectId(int projectId);
    }
}

