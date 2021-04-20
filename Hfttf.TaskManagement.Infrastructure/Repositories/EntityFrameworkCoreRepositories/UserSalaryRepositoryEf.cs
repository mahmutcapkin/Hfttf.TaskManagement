using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Infrastructure.Data.EntityFrameworkCore;
using Hfttf.TaskManagement.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Infrastructure.Repositories.EntityFrameworkCoreRepositories
{
    public class UserSalaryRepositoryEf : Repository<UserSalary>, IUserSalaryRepository
    {
        public UserSalaryRepositoryEf(TaskManagementContext taskManagementContext) : base(taskManagementContext)
        {
        }
        public async Task<IReadOnlyList<UserSalary>> GetListWithUser()
        {
            var data = await _taskManagementContext.UserSalaries.Include(x => x.ApplicationUser).AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<IReadOnlyList<UserSalary>> GetListWithUserByUserId(string userId)
        {
            var data = await _taskManagementContext.UserSalaries.Where(x => x.ApplicationUserId == userId).Include(x => x.ApplicationUser).AsNoTracking().ToListAsync();
            return data;
        }
    }
}
