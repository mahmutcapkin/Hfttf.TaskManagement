using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Infrastructure.Data.EntityFrameworkCore;
using Hfttf.TaskManagement.Infrastructure.Repositories.Base;

namespace Hfttf.TaskManagement.Infrastructure.Repositories.EntityFrameworkCoreRepositories
{
    public class HolidayRepositoryEf : Repository<Holiday>, IHolidayRepository
    {
        public HolidayRepositoryEf(TaskManagementContext taskManagementContext) : base(taskManagementContext)
        {
        }
    }
}
