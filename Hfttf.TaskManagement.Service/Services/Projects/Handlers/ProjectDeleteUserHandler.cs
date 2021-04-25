using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Projects.Commands;
using Hfttf.TaskManagement.Service.Services.Projects.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Projects.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Projects.Handlers
{
    public class ProjectDeleteUserHandler : BaseProjectHandler, IRequestHandler<ProjectDeleteUserCommand, Response>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ProjectDeleteUserHandler(IProjectRepository projectRepository, UserManager<ApplicationUser> userManager) : base(projectRepository)
        {
            _userManager = userManager;
        }
        public async Task<Response> Handle(ProjectDeleteUserCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetProjectWithUsersAndTasks(request.Id);
            List<ApplicationUser> userList = (List<ApplicationUser>)project.ApplicationUsers;
            foreach (var item in request.UserIds)
            {
                var userId = await _userManager.FindByIdAsync(item);
                if (userId != null)
                {
                    userList.Remove(userId);
                }
            }          
            project.ApplicationUsers = userList;
            var response = await _projectRepository.UpdateAsync(project);
            var projectResponse = TaskManagementMapper.Mapper.Map<ProjectResponse>(response);
            var result = Response.Success(projectResponse, 200);
            return result;

        }

    }
}

