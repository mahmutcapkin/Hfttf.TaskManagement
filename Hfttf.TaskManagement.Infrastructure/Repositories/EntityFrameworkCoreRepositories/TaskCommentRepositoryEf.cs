using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Infrastructure.Data.EntityFrameworkCore;
using Hfttf.TaskManagement.Infrastructure.Repositories.Base;

namespace Hfttf.TaskManagement.Infrastructure.Repositories.EntityFrameworkCoreRepositories
{
    public class TaskCommentRepositoryEf : Repository<TaskComment>, ITaskCommentRepository
    {
        public TaskCommentRepositoryEf(TaskManagementContext taskManagementContext) : base(taskManagementContext)
        {
        }
    }
}
