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
    public class LeaderRepositoryEf : Repository<Leader>, ILeaderRepository
    {
        public LeaderRepositoryEf(TaskManagementContext taskManagementContext) : base(taskManagementContext)
        {
        }
        public async Task<IReadOnlyList<Leader>> GetListWithUserAndProject()
        {
            var data = await _taskManagementContext.Leaders.Include(x => x.ApplicationUser).Include(x => x.Project).AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<IReadOnlyList<Leader>> GetListWithUserByUserId(string userId)
        {
            var data = await _taskManagementContext.Leaders.Where(x => x.ApplicationUserId == userId).Include(x => x.ApplicationUser).Include(x => x.Project).AsNoTracking().ToListAsync();
            return data;
        }
        public async Task<IReadOnlyList<Leader>> GetListByProjectId(int? projectId)
        {
            var data = await _taskManagementContext.Leaders.Where(x => x.ProjectId == projectId).Include(x => x.ApplicationUser).Include(x => x.Project).AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<IReadOnlyList<Leader>> GetListByUserIdandProjectId(string userId, int? projectId)
        {
            var data = await _taskManagementContext.Leaders.Where(x => x.ApplicationUserId == userId && x.ProjectId==projectId).Include(x => x.ApplicationUser).Include(x => x.Project).AsNoTracking().ToListAsync();
            return data;
        }
        public async Task<Leader> GetLeaderWithUserandProject(int id)
        {
            var data = await _taskManagementContext.Leaders.Include(x => x.ApplicationUser).Include(x => x.Project).AsNoTracking().FirstOrDefaultAsync(x => x.Id==id);
            return data;
        }

        public async Task<Leader> GetLeaderByUserIdandProjectId(string userId, int projectId)
        {
            var data = await _taskManagementContext.Leaders.Include(x => x.ApplicationUser).Include(x => x.Project).AsNoTracking().FirstOrDefaultAsync(x => x.ApplicationUserId == userId && x.ProjectId == projectId);
            return data;
        }
    }
}
