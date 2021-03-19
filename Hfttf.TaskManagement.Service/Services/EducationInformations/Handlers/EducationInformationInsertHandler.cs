using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.EducationInformations.Commands;
using Hfttf.TaskManagement.Service.Services.EducationInformations.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.EducationInformations.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.EducationInformations.Handlers
{
    public class EducationInformationInsertHandler : BaseEducationInformationHandler, IRequestHandler<EducationInformationInsertCommand, Response>
    {
        public EducationInformationInsertHandler(IEducationInformationRepository EducationInformationRepository) : base(EducationInformationRepository)
        {

        }
        public async Task<Response> Handle(EducationInformationInsertCommand request, CancellationToken cancellationToken)
        {
            var educationInformation = TaskManagementMapper.Mapper.Map<EducationInformation>(request);
            var response = await _educationInformationRepository.AddAsync(educationInformation);
            var educationInformationresponse = TaskManagementMapper.Mapper.Map<EducationInformationResponse>(response);
            var result = Response.Success(educationInformationresponse, 200);
            return result;
        }
    }
}
