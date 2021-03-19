using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Infrastructure.Data.EntityFrameworkCore;
using Hfttf.TaskManagement.Infrastructure.Repositories.Base;

namespace Hfttf.TaskManagement.Infrastructure.Repositories.EntityFrameworkCoreRepositories
{
    public class EducationInformationRepositoryEf : Repository<EducationInformation>, IEducationInformationRepository
    {
        public EducationInformationRepositoryEf(TaskManagementContext taskManagementContext) : base(taskManagementContext)
        {
        }
    }
}
