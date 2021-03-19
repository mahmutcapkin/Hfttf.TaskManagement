using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Infrastructure.Data.EntityFrameworkCore;
using Hfttf.TaskManagement.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = Hfttf.TaskManagement.Core.Entities.Task;

namespace Hfttf.TaskManagement.Infrastructure.Repositories.EntityFrameworkCoreRepositories
{
    public class TaskRepositoryEf : Repository<Task>, ITaskRepository
    {
        public TaskRepositoryEf(TaskManagementContext taskManagementContext) : base(taskManagementContext)
        {
        }

        public async Task<IReadOnlyList<Task>> GetListByProjectIdPagination(int projectId, int pageNumber, int pageSize)
        {
            var pagedData = await _taskManagementContext.Tasks.Where(p => p.ProjectId == projectId).Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
            return pagedData;
        }
    }
}
