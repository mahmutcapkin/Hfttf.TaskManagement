using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Experiences.Commands;
using Hfttf.TaskManagement.Service.Services.Experiences.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Experiences.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Experiences.Handlers
{
    public class ExperienceDeleteHandler : BaseExperienceHandler, IRequestHandler<ExperienceDeleteCommand, Response>
    {
        public ExperienceDeleteHandler(IExperienceRepository ExperienceRepository) : base(ExperienceRepository)
        {

        }
        public async Task<Response> Handle(ExperienceDeleteCommand request, CancellationToken cancellationToken)
        {
            var experience = TaskManagementMapper.Mapper.Map<Experience>(request);
            var response = await _experienceRepository.DeleteAsync(experience);
            var experienceresponse = TaskManagementMapper.Mapper.Map<ExperienceResponse>(response);
            var result = Response.Success(experienceresponse, 200);
            return result;
        }
    }
}
