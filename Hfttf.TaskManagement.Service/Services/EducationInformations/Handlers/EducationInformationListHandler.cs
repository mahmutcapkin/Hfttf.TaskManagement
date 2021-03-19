using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.EducationInformations.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.EducationInformations.Queries;
using Hfttf.TaskManagement.Service.Services.EducationInformations.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.EducationInformations.Handlers
{
    public class EducationInformationListHandler : BaseEducationInformationHandler, IRequestHandler<EducationInformationListQuery, Response>
    {
        public EducationInformationListHandler(IEducationInformationRepository EducationInformationRepository) : base(EducationInformationRepository)
        {

        }
        public async Task<Response> Handle(EducationInformationListQuery request, CancellationToken cancellationToken)
        {
            var educationInformation = await _educationInformationRepository.GetAllAsync();
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<EducationInformationResponse>>(educationInformation);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
