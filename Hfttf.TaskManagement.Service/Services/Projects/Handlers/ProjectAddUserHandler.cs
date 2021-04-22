using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Projects.Commands;
using Hfttf.TaskManagement.Service.Services.Projects.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Projects.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Projects.Handlers
{
    public class ProjectAddUserHandler : BaseProjectHandler, IRequestHandler<ProjectAddUserCommand, Response>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ProjectAddUserHandler(IProjectRepository projectRepository, UserManager<ApplicationUser> userManager) : base(projectRepository)
        {
            _userManager = userManager;
        }
        public async Task<Response> Handle(ProjectAddUserCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.FindAsync(x => x.Id == request.Id);
            List<ApplicationUser> users = new List<ApplicationUser>();
            foreach (var item in request.UserIds)
            {
                var user = await _userManager.FindByIdAsync(item);
                if (user != null)
                {
                    users.Add(user);
                }
                
            }
            project.ApplicationUsers = users;

            var response = await _projectRepository.UpdateAsync(project);
            var projectResponse = TaskManagementMapper.Mapper.Map<ProjectResponse>(response);
            var result = Response.Success(projectResponse, 200);
            return result;
        }
    }
}
