using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Projects.Commands;
using Hfttf.TaskManagement.Service.Services.Projects.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Projects.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Projects.Handlers
{
    public class ProjectUpdateHandler : BaseProjectHandler, IRequestHandler<ProjectUpdateCommand, Response>
    {
        public ProjectUpdateHandler(IProjectRepository projectRepository) : base(projectRepository)
        {
        }
        public async Task<Response> Handle(ProjectUpdateCommand request, CancellationToken cancellationToken)
        {
            var project = TaskManagementMapper.Mapper.Map<Project>(request);
            project.UpdatedDate = DateTime.Now;
            var projectGetById = await _projectRepository.GetByIdAsync(request.Id);
            project.CreatedDate = projectGetById.CreatedDate;
            project.CreateBy = projectGetById.CreateBy;
            var response = await _projectRepository.UpdateAsync(project);
            var projectResponse = TaskManagementMapper.Mapper.Map<ProjectResponse>(response);
            var result = Response.Success(projectResponse, 200);
            return result;
        }
    }
}
