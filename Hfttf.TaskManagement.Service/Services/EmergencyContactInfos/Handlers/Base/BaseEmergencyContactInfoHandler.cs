using Hfttf.TaskManagement.Core.Repositories;

namespace Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Handlers.Base
{
    public class BaseEmergencyContactInfoHandler
    {
        protected readonly IEmergencyContactInfoRepository _emergencyContactInfoRepository;

        public BaseEmergencyContactInfoHandler(IEmergencyContactInfoRepository emergencyContactInfoRepository)
        {
            _emergencyContactInfoRepository = emergencyContactInfoRepository;
        }
    }
}
