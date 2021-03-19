using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Projects.Commands;
using Hfttf.TaskManagement.Service.Services.Projects.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Projects.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Projects.Handlers
{
    public class ProjectDeleteHandler : BaseProjectHandler, IRequestHandler<ProjectDeleteCommand, Response>
    {
        public ProjectDeleteHandler(IProjectRepository projectRepository) : base(projectRepository)
        {
        }
        public async Task<Response> Handle(ProjectDeleteCommand request, CancellationToken cancellationToken)
        {
            var project = TaskManagementMapper.Mapper.Map<Project>(request);
            var response = await _projectRepository.DeleteAsync(project);
            var projectResponse = TaskManagementMapper.Mapper.Map<ProjectResponse>(response);
            var result = Response.Success(projectResponse, 200);
            return result;
        }
    }
}
