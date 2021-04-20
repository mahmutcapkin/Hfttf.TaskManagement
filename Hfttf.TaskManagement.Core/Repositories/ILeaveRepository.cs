using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Core.Repositories
{
    public interface ILeaveRepository : IRepository<Leave>
    {
        Task<IReadOnlyList<Leave>> GetListWithUser();
        Task<IReadOnlyList<Leave>> GetListWithUserByUserId(string userId);
    }
}
