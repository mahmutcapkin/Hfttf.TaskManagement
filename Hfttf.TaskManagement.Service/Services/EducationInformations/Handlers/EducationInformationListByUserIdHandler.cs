using Hfttf.TaskManagement.Core.Entities;
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
    public class EducationInformationListByUserIdHandler : BaseEducationInformationHandler, IRequestHandler<EducationInformationListByUserIdQuery, Response>
    {
        public EducationInformationListByUserIdHandler(IEducationInformationRepository EducationInformationRepository) : base(EducationInformationRepository)
        {

        }
        public async Task<Response> Handle(EducationInformationListByUserIdQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<EducationInformation> educationInformation;
            if (request.UserId == null)
            {
                educationInformation = await _educationInformationRepository.GetListWithUser();
            }
            else
            {
                educationInformation = await _educationInformationRepository.GetListWithUserByUserId(request.UserId);
            } 
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<EducationInformationResponse>>(educationInformation);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
