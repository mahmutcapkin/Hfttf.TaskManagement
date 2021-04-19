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
    public class UserRepositoryEf : RepositoryUser<ApplicationUser>, IUserRepository
    {

        public UserRepositoryEf(TaskManagementContext taskManagementContext) : base(taskManagementContext)
        {
        }

        public async Task<IReadOnlyList<ApplicationUser>> GetUserListWithJobByJobId(int? jobId)
        {
            List<ApplicationUser> user = new List<ApplicationUser>();
            if (jobId == null)
            {
                user = await _taskManagementContext.Users.ToListAsync();
                return user;
            }
            else
            {
                user = await _taskManagementContext.Users.Include(a => a.Job).Where(a => a.JobId == jobId).ToListAsync();
                return user;
            }
        }
    }
}
