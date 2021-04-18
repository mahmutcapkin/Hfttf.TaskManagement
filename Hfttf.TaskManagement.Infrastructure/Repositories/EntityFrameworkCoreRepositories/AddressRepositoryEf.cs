using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Infrastructure.Data.EntityFrameworkCore;
using Hfttf.TaskManagement.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Infrastructure.Repositories.EntityFrameworkCoreRepositories
{
    public class AddressRepositoryEf : Repository<Address>, IAddressRepository
    {
        public AddressRepositoryEf(TaskManagementContext taskManagementContext) : base(taskManagementContext)
        {
        }

        public async Task<IReadOnlyList<Address>> GetListWithUser()
        {
            var data = await _taskManagementContext.Addresses.Include(x => x.ApplicationUser).AsNoTracking().ToListAsync();
            return data;
        }
    }
}
