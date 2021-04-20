using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Core.Repositories
{
    public interface IExperienceRepository : IRepository<Experience>
    {
        Task<IReadOnlyList<Experience>> GetListWithUser();
        Task<IReadOnlyList<Experience>> GetListWithUserByUserId(string userId);
        Task<Experience> GetExperienceWithUserById(int id);
    }
}
