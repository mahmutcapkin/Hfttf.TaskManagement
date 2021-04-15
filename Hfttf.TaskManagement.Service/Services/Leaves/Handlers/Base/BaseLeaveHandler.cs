using Hfttf.TaskManagement.Core.Repositories;

namespace Hfttf.TaskManagement.Service.Services.Leaves.Handlers.Base
{
    public class BaseLeaveHandler
    {
        protected readonly ILeaveRepository _leaveRepository;

        public BaseLeaveHandler(ILeaveRepository leaveRepository)
        {
            _leaveRepository = leaveRepository;
        }
    }
}
