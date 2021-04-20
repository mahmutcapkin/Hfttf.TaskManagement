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
    public class ExperienceListHandler : BaseExperienceHandler, IRequestHandler<ExperienceListQuery, Response>
    {
        public ExperienceListHandler(IExperienceRepository ExperienceRepository) : base(ExperienceRepository)
        {

        }
        public async Task<Response> Handle(ExperienceListQuery request, CancellationToken cancellationToken)
        {
            var experience = await _experienceRepository.GetListWithUser();
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<ExperienceResponse>>(experience);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
