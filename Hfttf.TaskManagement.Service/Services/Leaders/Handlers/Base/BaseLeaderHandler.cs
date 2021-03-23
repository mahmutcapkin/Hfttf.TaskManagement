using Hfttf.TaskManagement.Core.Repositories;

namespace Hfttf.TaskManagement.Service.Services.Leaders.Handlers.Base
{
    public class BaseLeaderHandler
    {
        protected readonly ILeaderRepository _leaderRepository;

        public BaseLeaderHandler(ILeaderRepository leaderRepository)
        {
            _leaderRepository = leaderRepository;
        }
    }
}
