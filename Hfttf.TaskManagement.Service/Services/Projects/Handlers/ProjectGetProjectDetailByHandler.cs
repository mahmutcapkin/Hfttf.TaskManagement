using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Projects.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Projects.Queries;
using Hfttf.TaskManagement.Service.Services.Projects.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Projects.Handlers
{
    public class ProjectGetProjectDetailByHandler : BaseProjectHandler, IRequestHandler<ProjectGetProjectDetailByIdQuery, Response>
    {
        public ProjectGetProjectDetailByHandler(IProjectRepository projectRepository) : base(projectRepository)
        {
        }
        public async Task<Response> Handle(ProjectGetProjectDetailByIdQuery request, CancellationToken cancellationToken)
        {

            var project = await _projectRepository.GetProjectDetailById(request.Id);
            var projectResponse = TaskManagementMapper.Mapper.Map<IEnumerable<ProjectResponse>>(project);
            var response = Response.Success(projectResponse, 200);
            return response;
        }
    }
}
