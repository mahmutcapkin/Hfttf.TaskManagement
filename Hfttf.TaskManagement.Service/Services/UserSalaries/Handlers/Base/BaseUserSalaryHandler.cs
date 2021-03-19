using Hfttf.TaskManagement.Core.Repositories;

namespace Hfttf.TaskManagement.Service.Services.UserSalaries.Handlers.Base
{
    public class BaseUserSalaryHandler
    {
        protected readonly IUserSalaryRepository _userSalaryRepository;

        public BaseUserSalaryHandler(IUserSalaryRepository userSalaryRepository)
        {
            _userSalaryRepository = userSalaryRepository;
        }

    }
}
