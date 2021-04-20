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
    public class JobRepositoryEf : Repository<Job>, IJobRepository
    {
        public JobRepositoryEf(TaskManagementContext taskManagementContext) : base(taskManagementContext)
        {
        }
        public async Task<IReadOnlyList<Job>> GetListWithUser()
        {
            var data = await _taskManagementContext.Jobs.Include(x => x.ApplicationUsers).AsNoTracking().ToListAsync();
            return data;
        }
        public async Task<Job> GetJobWithUsers(int id)
        {
            var data = await _taskManagementContext.Jobs.Include(x => x.ApplicationUsers).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }
    }
}
