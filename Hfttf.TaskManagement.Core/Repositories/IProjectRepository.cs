using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Core.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<IReadOnlyList<Project>> GetListByUserId(string userId);
        Task<IReadOnlyList<Project>> GetListPaginationByUserId(string userId, int pageNumber, int pageSize);
        Task<IReadOnlyList<Project>> GetProjectDetailById(int id);
    }
}
