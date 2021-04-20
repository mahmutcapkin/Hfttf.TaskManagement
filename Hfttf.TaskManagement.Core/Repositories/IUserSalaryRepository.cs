using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Core.Repositories
{
    public interface IUserSalaryRepository : IRepository<UserSalary>
    {
        Task<IReadOnlyList<UserSalary>> GetListWithUser();
        Task<IReadOnlyList<UserSalary>> GetListWithUserByUserId(string userId);
    }
}

