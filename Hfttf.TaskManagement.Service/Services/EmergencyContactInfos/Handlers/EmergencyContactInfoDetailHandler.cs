using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Queries;
using Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Handlers
{
    public class EmergencyContactInfoDetailHandler : BaseEmergencyContactInfoHandler, IRequestHandler<EmergencyContactInfoDetailQuery, Response>
    {
        public EmergencyContactInfoDetailHandler(IEmergencyContactInfoRepository emergencyContactInfoRepository) : base(emergencyContactInfoRepository)
        {

        }
        public async Task<Response> Handle(EmergencyContactInfoDetailQuery request, CancellationToken cancellationToken)
        {
            var emergencyContactInfo = await _emergencyContactInfoRepository.GetEmergencyContactInfoWithUserById(request.Id);
            var emergencyContactInforesponse = TaskManagementMapper.Mapper.Map<EmergencyContactInfoResponse>(emergencyContactInfo);
            var result = Response.Success(emergencyContactInforesponse, 200);
            return result;
        }
    }
}
