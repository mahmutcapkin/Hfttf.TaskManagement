using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Services.Roles.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Roles.Queries;
using Hfttf.TaskManagement.Service.Services.Roles.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Roles.Handlers
{
    public class RoleGetUserRolesHandler : BaseRoleHandler, IRequestHandler<RoleGetUserRolesQuery, Response>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public RoleGetUserRolesHandler(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager, IRoleRepository roleRepository) : base(roleManager, roleRepository)
        {
            _userManager = userManager;
        }

        public async Task<Response> Handle(RoleGetUserRolesQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user != null)
            {
                var applicationUserRoles = await _userManager.GetRolesAsync(user);
                var applicationRoles = await _roleManager.Roles.ToListAsync();
                if (applicationUserRoles != null)
                {
                    List<RoleAssignModelResponse> roleAssignModelResponses = new List<RoleAssignModelResponse>();

                    foreach (var role in applicationRoles)
                    {
                        RoleAssignModelResponse r = new RoleAssignModelResponse();
                        r.RoleId = role.Id;
                        r.RoleName = role.Name;
                        if (applicationUserRoles.Contains(role.Name))
                        {
                            r.Exist = true;
                        }
                        else
                        {
                            r.Exist = false;
                        }
                        roleAssignModelResponses.Add(r);
                    }

                    var result = Response.Success(roleAssignModelResponses, 200);
                    return result;
                }
            }
            var roleResult = Response.UnSuccess("User Not Found", 404, true);
            return roleResult;
        }

    }
}
