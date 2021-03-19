using Hfttf.TaskManagement.Core.Repositories;

namespace Hfttf.TaskManagement.Service.Services.TaskComments.Handlers.Base
{
    public class BaseTaskCommentHandler
    {
        protected readonly ITaskCommentRepository _taskCommentRepository;

        public BaseTaskCommentHandler(ITaskCommentRepository taskCommentRepository)
        {
            _taskCommentRepository = taskCommentRepository;
        }
    }
}
