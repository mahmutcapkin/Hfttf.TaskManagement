using Hfttf.TaskManagement.Core.Repositories;

namespace Hfttf.TaskManagement.Service.Services.Experiences.Handlers.Base
{
    public class BaseExperienceHandler
    {
        protected readonly IExperienceRepository _experienceRepository;

        public BaseExperienceHandler(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }
    }
}
