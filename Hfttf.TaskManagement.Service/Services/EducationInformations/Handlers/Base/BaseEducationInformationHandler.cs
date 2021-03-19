using Hfttf.TaskManagement.Core.Repositories;

namespace Hfttf.TaskManagement.Service.Services.EducationInformations.Handlers.Base
{
    public class BaseEducationInformationHandler
    {
        protected readonly IEducationInformationRepository _educationInformationRepository;

        public BaseEducationInformationHandler(IEducationInformationRepository educationInformationRepository)
        {
            _educationInformationRepository = educationInformationRepository;
        }
    }
}
