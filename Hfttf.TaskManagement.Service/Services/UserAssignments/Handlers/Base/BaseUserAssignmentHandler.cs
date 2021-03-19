using Hfttf.TaskManagement.Core.Repositories;

namespace Hfttf.TaskManagement.Service.Services.UserAssignments.Handlers.Base
{
    public class BaseUserAssignmentHandler
    {
        protected readonly IUserAssignmentRepository _UserAssignmentRepository;

        public BaseUserAssignmentHandler(IUserAssignmentRepository UserAssignmentRepository)
        {
            _UserAssignmentRepository = UserAssignmentRepository;
        }

    }
}
