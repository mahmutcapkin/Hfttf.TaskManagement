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
    public class UserAssignmentRepositoryEf : Repository<UserAssignment>, IUserAssignmentRepository
    {
        public UserAssignmentRepositoryEf(TaskManagementContext taskManagementContext) : base(taskManagementContext)
        {
        }
        public async Task<IReadOnlyList<UserAssignment>> GetListWithUserandTask()
        {
            var data = await _taskManagementContext.UserAssignments.Include(x => x.ApplicationUser).Include(x => x.Task).AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<IReadOnlyList<UserAssignment>> GetListWithUserandTaskByUserId(string userId)
        {
            var data = await _taskManagementContext.UserAssignments.Where(x => x.ApplicationUserId == userId).Include(x => x.ApplicationUser).Include(x => x.Task).AsNoTracking().ToListAsync();
            return data;
        }
    }
}
