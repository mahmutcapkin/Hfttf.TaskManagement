using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.EducationInformations.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.EducationInformations.Queries;
using Hfttf.TaskManagement.Service.Services.EducationInformations.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.EducationInformations.Handlers
{
    public class EducationInformationDetailHandler : BaseEducationInformationHandler, IRequestHandler<EducationInformationDetailQuery, Response>
    {
        public EducationInformationDetailHandler(IEducationInformationRepository EducationInformationRepository) : base(EducationInformationRepository)
        {

        }
        public async Task<Response> Handle(EducationInformationDetailQuery request, CancellationToken cancellationToken)
        {
            var educationInformation = await _educationInformationRepository.GetEducationInformationWithUserById(request.Id);
            var response = TaskManagementMapper.Mapper.Map<EducationInformationResponse>(educationInformation);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
