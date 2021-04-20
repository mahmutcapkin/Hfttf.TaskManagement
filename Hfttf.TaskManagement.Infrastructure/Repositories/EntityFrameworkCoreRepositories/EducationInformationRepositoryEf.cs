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
    public class EducationInformationRepositoryEf : Repository<EducationInformation>, IEducationInformationRepository
    {
        public EducationInformationRepositoryEf(TaskManagementContext taskManagementContext) : base(taskManagementContext)
        {
        }
        public async Task<IReadOnlyList<EducationInformation>> GetListWithUser()
        {
            var data = await _taskManagementContext.EducationInformations.Include(x => x.ApplicationUser).AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<IReadOnlyList<EducationInformation>> GetListWithUserByUserId(string userId)
        {
            var data = await _taskManagementContext.EducationInformations.Where(x => x.ApplicationUserId == userId).Include(x => x.ApplicationUser).AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<EducationInformation> GetEducationInformationWithUserById(int id)
        {
            var data = await _taskManagementContext.EducationInformations.Include(x => x.ApplicationUser).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }
    }
}
