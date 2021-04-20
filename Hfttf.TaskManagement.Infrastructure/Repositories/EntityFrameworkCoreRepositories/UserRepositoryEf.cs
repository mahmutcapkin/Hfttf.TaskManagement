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

        public async Task<IReadOnlyList<ApplicationUser>> GetUserList()
        {
            var data = await _taskManagementContext.Users
                .Include(x => x.UserSalaries)
                .Include(x => x.UserAssignments)
                .Include(x => x.Leaves)
                .Include(x => x.Leaders)
                .Include(x => x.Job)
                .Include(x => x.Experiences)
                .Include(x => x.EmergencyContactInfos)
                .Include(x => x.EducationInformations)
                .Include(x => x.Department)
                .Include(x => x.BankInformations)
                .Include(x => x.Addresses)
                .ToListAsync();
            return data;
        }

        public async Task<ApplicationUser> GetUserDetailById(string userId)
        {
            var data = await _taskManagementContext.Users
                .Include(x => x.UserSalaries)
                .Include(x => x.UserAssignments)
                .Include(x => x.Leaves)
                .Include(x => x.Leaders)
                .Include(x => x.Job)
                .Include(x => x.Experiences)
                .Include(x => x.EmergencyContactInfos)
                .Include(x => x.EducationInformations)
                .Include(x => x.Department)
                .Include(x => x.BankInformations)
                .Include(x => x.Addresses)
                .FirstOrDefaultAsync(x=>x.Id==userId);
            return data;
        }
    }
}
