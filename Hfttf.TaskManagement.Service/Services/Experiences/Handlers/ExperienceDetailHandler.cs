using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Experiences.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Experiences.Queries;
using Hfttf.TaskManagement.Service.Services.Experiences.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Experiences.Handlers
{
    public class ExperienceDetailHandler : BaseExperienceHandler, IRequestHandler<ExperienceDetailQuery, Response>
    {
        public ExperienceDetailHandler(IExperienceRepository ExperienceRepository) : base(ExperienceRepository)
        {

        }
        public async Task<Response> Handle(ExperienceDetailQuery request, CancellationToken cancellationToken)
        {
            var experience = await _experienceRepository.GetExperienceWithUserById(request.Id);
            var response = TaskManagementMapper.Mapper.Map<ExperienceResponse>(experience);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
