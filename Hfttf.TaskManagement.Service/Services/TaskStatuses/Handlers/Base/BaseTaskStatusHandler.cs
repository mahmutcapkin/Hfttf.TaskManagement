using Hfttf.TaskManagement.Core.Repositories;

namespace Hfttf.TaskManagement.Service.Services.TaskStatuses.Handlers.Base
{
    public class BaseTaskStatusHandler
    {
        protected readonly ITaskStatusRepository _taskStatusRepository;

        public BaseTaskStatusHandler(ITaskStatusRepository taskStatusRepository)
        {
            _taskStatusRepository = taskStatusRepository;
        }
    }
}
