using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Roles.Commands;
using Hfttf.TaskManagement.Service.Services.Roles.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Roles.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Roles.Handlers
{
    public class RoleAssignRoleToUserHandler : BaseRoleHandler, IRequestHandler<RoleAssignRoleToUserCommand, Response>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public RoleAssignRoleToUserHandler(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager, IRoleRepository roleRepository) : base(roleManager, roleRepository)
        {
            _userManager = userManager;
        }

        public async Task<Response> Handle(RoleAssignRoleToUserCommand request, CancellationToken cancellationToken)
        {
          
            var user = await _userManager.FindByIdAsync(request.UserId);  // rol eklenecek user
            var userRoles = await _userManager.GetRolesAsync(user);  //kullanıcı rolleri 
            var assignRoleUser = new ApplicationRole();
            List<string> applicationRoles = new List<string>();
            foreach (var assignRole in request.RoleId)
            {
                assignRoleUser = await _roleManager.FindByIdAsync(assignRole);
                if (assignRoleUser != null)
                {
                    applicationRoles.Add(assignRoleUser.Name);
                }
            }
            var assign = applicationRoles.Except(userRoles).ToList();
            IdentityResult result = new IdentityResult();
            foreach (var role in assign)
            {
                result = await _userManager.AddToRoleAsync(user, role);
               
            }

            if (result.Succeeded)
            {
                return Response.Success(200);
            }
            else
            {
                return Response.UnSuccess("Rol Atanamadı", 404, true);
            }
     
        }
    }
}
