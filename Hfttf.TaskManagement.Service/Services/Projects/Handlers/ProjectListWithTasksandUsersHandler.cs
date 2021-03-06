using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Projects.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Projects.Queries;
using Hfttf.TaskManagement.Service.Services.Projects.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Projects.Handlers
{
    public class ProjectListWithTasksandUsersHandler : BaseProjectHandler, IRequestHandler<ProjectListWithTasksandUsersQuery, Response>
    {
        public ProjectListWithTasksandUsersHandler(IProjectRepository projectRepository) : base(projectRepository)
        {
        }

        public async Task<Response> Handle(ProjectListWithTasksandUsersQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetListWithUsersAndTasks();
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<ProjectResponse>>(projects);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
