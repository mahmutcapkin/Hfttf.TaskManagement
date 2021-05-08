using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Roles.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Roles.Queries;
using Hfttf.TaskManagement.Service.Services.Roles.Responses;
using Hfttf.TaskManagement.Service.Services.Users.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Roles.Handlers
{
    public class RoleDetailWithUsersHandler : BaseRoleHandler, IRequestHandler<RoleDetailWithUsersQuery, Response>
    {
        public RoleDetailWithUsersHandler(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager, IRoleRepository roleRepository) : base(roleManager, userManager, roleRepository)
        {
        }
        public async Task<Response> Handle(RoleDetailWithUsersQuery request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(request.Id);
            var users = await _userManager.GetUsersInRoleAsync(role.Name);   
            if (role == null)
            {
                var unSuccesResult = Response.UnSuccess("Rol bulunamadı", 400, true);
                return unSuccesResult;

            }
            var response = TaskManagementMapper.Mapper.Map<RoleResponse>(role);
            var responseUser = TaskManagementMapper.Mapper.Map<List<UserResponse>>(users);
            response.ApplicationUsers = responseUser;
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
