using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Commands;
using Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Handlers
{
    public class EmergencyContactInfoUpdateHandler : BaseEmergencyContactInfoHandler, IRequestHandler<EmergencyContactInfoUpdateCommand, Response>
    {
        public EmergencyContactInfoUpdateHandler(IEmergencyContactInfoRepository emergencyContactInfoRepository) : base(emergencyContactInfoRepository)
        {

        }
        public async Task<Response> Handle(EmergencyContactInfoUpdateCommand request, CancellationToken cancellationToken)
        {
            var emergencyContactInfo = TaskManagementMapper.Mapper.Map<EmergencyContactInfo>(request);
            var response = await _emergencyContactInfoRepository.UpdateAsync(emergencyContactInfo);
            var emergencyContactInforesponse = TaskManagementMapper.Mapper.Map<EmergencyContactInfoResponse>(response);
            var result = Response.Success(emergencyContactInforesponse, 200);
            return result;

        }
    }
}
