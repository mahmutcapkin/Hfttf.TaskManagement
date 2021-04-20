using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Core.Repositories
{
    public interface ILeaderRepository : IRepository<Leader>
    {
        Task<IReadOnlyList<Leader>> GetListWithUserAndProject();
        Task<IReadOnlyList<Leader>> GetListWithUserByUserId(string userId);
        Task<IReadOnlyList<Leader>> GetListByProjectId(int? projectId);
        Task<IReadOnlyList<Leader>> GetListByUserIdandProjectId(string userId, int? projectId);
        Task<Leader> GetLeaderWithUserandProject(int id);
        Task<Leader> GetLeaderByUserIdandProjectId(string userId, int projectId);
    }
}
