using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Infrastructure.Data.EntityFrameworkCore;
using Hfttf.TaskManagement.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Infrastructure.Repositories.EntityFrameworkCoreRepositories
{
    public class TaskStatusRepositoryEf : Repository<TaskStatus>, ITaskStatusRepository
    {
        public TaskStatusRepositoryEf(TaskManagementContext taskManagementContext) : base(taskManagementContext)
        {
        }

        public async System.Threading.Tasks.Task<IReadOnlyList<TaskStatus>> GetTaskByProjectId()
        {
            return await _taskManagementContext.Set<TaskStatus>().AsNoTracking().Include(x => x.Tasks).ToListAsync();
        }

        public async System.Threading.Tasks.Task<TaskStatus> GetTaskStatusWithTasksByStatusNameId(int statusnameid)
        {
            var entity = await _taskManagementContext.Set<TaskStatus>().Include(a => a.Tasks).AsNoTracking().FirstOrDefaultAsync(x => x.StatusNameId == statusnameid);

            if (entity != null)
                _taskManagementContext.Entry(entity).State = EntityState.Detached;
            return entity;
        }
    }
}
