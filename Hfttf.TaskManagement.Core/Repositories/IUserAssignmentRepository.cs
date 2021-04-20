using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Core.Repositories
{
    public interface IUserAssignmentRepository : IRepository<UserAssignment>
    {
        Task<IReadOnlyList<UserAssignment>> GetListWithUserandTask();
        Task<IReadOnlyList<UserAssignment>> GetListWithUserandTaskByUserId(string userId);
    }
}

