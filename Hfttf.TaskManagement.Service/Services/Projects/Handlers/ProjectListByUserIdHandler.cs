using Hfttf.TaskManagement.Core.Entities;
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
            IReadOnlyList<Project> projects;
            if (request.UserId == null)
            {
                projects = await _projectRepository.GetListWithUsersAndTasks();
            }
            else
            {
                projects = await _projectRepository.GetListWithUsersAndTasksByUserId(request.UserId);
            }
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<ProjectResponse>>(projects);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
