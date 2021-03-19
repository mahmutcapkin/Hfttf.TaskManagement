using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Projects.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Projects.Queries;
using Hfttf.TaskManagement.Service.Services.Projects.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Projects.Handlers
{
    public class ProjectDetailHandler : BaseProjectHandler, IRequestHandler<ProjectDetailQuery, Response>
    {
        public ProjectDetailHandler(IProjectRepository projectRepository) : base(projectRepository)
        {
        }
        public async Task<Response> Handle(ProjectDetailQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.FindAsync(x => x.Id == request.Id);
            var projectResponse = TaskManagementMapper.Mapper.Map<ProjectResponse>(project);
            var response = Response.Success(projectResponse, 200);
            return response;
        }
    }
}
