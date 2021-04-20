using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Core.Repositories
{
    public interface IUserRepository : IRepositoryForUser<ApplicationUser>
    {
        Task<IReadOnlyList<ApplicationUser>> GetUserList();
        Task<ApplicationUser> GetUserDetailById(string userId);
    }
}
