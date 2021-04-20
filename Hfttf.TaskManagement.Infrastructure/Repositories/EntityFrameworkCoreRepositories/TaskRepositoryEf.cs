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
            var data = await _taskManagementContext.Tasks.Where(p => p.ProjectId == projectId).Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
            return data;
        }
        public async Task<IReadOnlyList<Task>> GetListByProjectId(int? projectId)
        {
            var data = await _taskManagementContext.Tasks.Where(p => p.ProjectId == projectId).Include(x=>x.Project).Include(x => x.TaskStatus).AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<IReadOnlyList<Task>> GetListByTaskStatusId(int taskStatusId)
        {
            var data = await _taskManagementContext.Tasks.Where(p => p.TaskStatusId == taskStatusId).Include(x=>x.Project).Include(x => x.TaskStatus).AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<IReadOnlyList<Task>> GetListWithStatusAndProject()
        {
            var data = await _taskManagementContext.Tasks.Include(x => x.Project).Include(x => x.TaskStatus).AsNoTracking().ToListAsync();
            return data;
        }
        public async Task<Task> GetTaskWithStatusAndProject(int id)
        {
            var data = await _taskManagementContext.Tasks.Include(x => x.Project).Include(x => x.TaskStatus).AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
            return data;
        }
    }
}
