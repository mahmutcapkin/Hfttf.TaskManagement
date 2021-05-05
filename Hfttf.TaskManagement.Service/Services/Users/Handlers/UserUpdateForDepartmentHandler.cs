using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Users.Commands;
using Hfttf.TaskManagement.Service.Services.Users.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Users.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Users.Handlers
{
    public class UserUpdateForDepartmentHandler : BaseUserHandler, IRequestHandler<UserUpdateForDepartmentCommand, Response>
    {
        public UserUpdateForDepartmentHandler(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IUserRepository userRepository) : base(userManager, roleManager, userRepository)
        {
        }

        public async Task<Response> Handle(UserUpdateForDepartmentCommand request, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByIdAsync(request.UserId);
            if (request.DepartmentId == 0 || request.DepartmentId == null)
            {
                user.DepartmentId = null;
            }
            else
            {
                user.DepartmentId = request.DepartmentId;
            }

            IdentityResult result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                var userResponse = TaskManagementMapper.Mapper.Map<UserResponse>(user);
                var response = Response.Success(userResponse, 200);
                return response;
            }
            else
            {
                return Response.UnSuccess("Kullanıcı güncellenemedi", 400, true);
            }

        }
    }
}
