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
    public class ProjectListByUserIdHandler : BaseProjectHandler, IRequestHandler<ProjectListByUserIdQuery, Response>
    {
        public ProjectListByUserIdHandler(IProjectRepository projectRepository) : base(projectRepository)
        {
        }

        public async Task<Response> Handle(ProjectListByUserIdQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetListByUserId(request.Id);
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<ProjectResponse>>(projects);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
