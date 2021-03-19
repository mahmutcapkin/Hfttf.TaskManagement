using Hfttf.TaskManagement.Core.Repositories;

namespace Hfttf.TaskManagement.Service.Services.Projects.Handlers.Base
{
    public class BaseProjectHandler
    {
        protected readonly IProjectRepository _projectRepository;

        public BaseProjectHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
    }
}
