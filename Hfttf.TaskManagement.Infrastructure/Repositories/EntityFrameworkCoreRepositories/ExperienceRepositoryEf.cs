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
    public class ExperienceRepositoryEf : Repository<Experience>, IExperienceRepository
    {
        public ExperienceRepositoryEf(TaskManagementContext taskManagementContext) : base(taskManagementContext)
        {
        }
        public async Task<IReadOnlyList<Experience>> GetListWithUser()
        {
            var data = await _taskManagementContext.Experiences.Include(x => x.ApplicationUser).AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<IReadOnlyList<Experience>> GetListWithUserByUserId(string userId)
        {
            var data = await _taskManagementContext.Experiences.Where(x => x.ApplicationUserId == userId).Include(x => x.ApplicationUser).AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<Experience> GetExperienceWithUserById(int id)
        {
            var data = await _taskManagementContext.Experiences.Include(x => x.ApplicationUser).AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
            return data;
        }
    }
}
