using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Experiences.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Experiences.Queries;
using Hfttf.TaskManagement.Service.Services.Experiences.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Experiences.Handlers
{
    public class ExperienceListByUserIdHandler : BaseExperienceHandler, IRequestHandler<ExperienceListByUserIdQuery, Response>
    {
        public ExperienceListByUserIdHandler(IExperienceRepository ExperienceRepository) : base(ExperienceRepository)
        {

        }
        public async Task<Response> Handle(ExperienceListByUserIdQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Experience> experience;
            if (request.UserId == null)
            {
                experience = await _experienceRepository.GetListWithUser();
            }
            else
            {
                experience = await _experienceRepository.GetListWithUserByUserId(request.UserId);
            }
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<ExperienceResponse>>(experience);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
