using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Infrastructure.Data.EntityFrameworkCore;
using Hfttf.TaskManagement.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskStatus = Hfttf.TaskManagement.Core.Entities.TaskStatus;

namespace Hfttf.TaskManagement.Infrastructure.Repositories.EntityFrameworkCoreRepositories
{
    public class TaskStatusRepositoryEf : Repository<TaskStatus>, ITaskStatusRepository
    {
        public TaskStatusRepositoryEf(TaskManagementContext taskManagementContext) : base(taskManagementContext)
        {
        }

        public async Task<IReadOnlyList<Core.Entities.TaskStatus>> GetTaskStatusesWithTasks()
        {
            var data = await _taskManagementContext.TaskStatuses.Include(x => x.Tasks).AsNoTracking().ToListAsync();
            return data;
            
        }
        public async Task<Core.Entities.TaskStatus> GetTaskStatusWithTasksByStatusId(int statusLevel)
        {
            var data = await _taskManagementContext.TaskStatuses.Include(x => x.Tasks).AsNoTracking().FirstOrDefaultAsync(x=>x.Id==statusLevel);
            return data;
        }

        public async Task<TaskStatus> GetTaskStatusWithTasksByStatusNameId(int statusnameid)
        {
            return null;
            //var entity = await _taskManagementContext.Set<TaskStatus>().Include(a => a.Tasks).AsNoTracking().FirstOrDefaultAsync(x => x.StatusNameId == statusnameid);

            //if (entity != null)
            //    _taskManagementContext.Entry(entity).State = EntityState.Detached;
            //return entity;
        }
    }
}
