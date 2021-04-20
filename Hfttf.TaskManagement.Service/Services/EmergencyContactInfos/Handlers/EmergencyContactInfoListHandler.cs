using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Queries;
using Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Handlers
{
    public class EmergencyContactInfoListHandler : BaseEmergencyContactInfoHandler, IRequestHandler<EmergencyContactInfoListQuery, Response>
    {
        public EmergencyContactInfoListHandler(IEmergencyContactInfoRepository emergencyContactInfoRepository) : base(emergencyContactInfoRepository)
        {

        }
        public async Task<Response> Handle(EmergencyContactInfoListQuery request, CancellationToken cancellationToken)
        {
            var emergencyContactInfo = await _emergencyContactInfoRepository.GetListWithUser();
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<EmergencyContactInfoResponse>>(emergencyContactInfo);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
