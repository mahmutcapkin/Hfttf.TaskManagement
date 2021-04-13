using Hfttf.TaskManagement.Core.Repositories;

namespace Hfttf.TaskManagement.Service.Services.Jobs.Handlers.Base
{
    public class BaseJobHandler
    {
        protected readonly IJobRepository _jobRepository;

        public BaseJobHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }
    }
}
