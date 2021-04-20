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
    public class EmergencyContactInfoRepositoryEf : Repository<EmergencyContactInfo>, IEmergencyContactInfoRepository
    {
        public EmergencyContactInfoRepositoryEf(TaskManagementContext taskManagementContext) : base(taskManagementContext)
        {
        }
        public async Task<IReadOnlyList<EmergencyContactInfo>> GetListWithUser()
        {
            var data = await _taskManagementContext.EmergencyContactInfos.Include(x => x.ApplicationUser).AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<IReadOnlyList<EmergencyContactInfo>> GetListWithUserByUserId(string userId)
        {
            var data = await _taskManagementContext.EmergencyContactInfos.Where(x => x.ApplicationUserId == userId).Include(x => x.ApplicationUser).AsNoTracking().ToListAsync();
            return data;
        }
        public async Task<EmergencyContactInfo> GetEmergencyContactInfoWithUserById(int id)
        {
            var data = await _taskManagementContext.EmergencyContactInfos.Include(x => x.ApplicationUser).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }
    }
}
