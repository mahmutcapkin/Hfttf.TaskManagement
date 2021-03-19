using Hfttf.TaskManagement.Core.Repositories;

namespace Hfttf.TaskManagement.Service.Services.Tasks.Handlers.Base
{
   public class BaseTaskHandler
    {
        protected readonly ITaskRepository _taskRepository;

        public BaseTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
    }
}
