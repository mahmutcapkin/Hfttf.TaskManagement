using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Services.Roles.Commands;
using Hfttf.TaskManagement.Service.Services.Roles.Handlers.Base;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Roles.Handlers
{
    public class RoleDeleteRoleToUserHandler : BaseRoleHandler, IRequestHandler<RoleDeleteRoleToUserCommand, Response>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public RoleDeleteRoleToUserHandler(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager, IRoleRepository roleRepository) : base(roleManager, roleRepository)
        {
            _userManager = userManager;
        }

        public async Task<Response> Handle(RoleDeleteRoleToUserCommand request, CancellationToken cancellationToken)
        {
           
            var user = await _userManager.FindByIdAsync(request.UserId);  // rol silinecek user
            var userRoles = await _userManager.GetRolesAsync(user);  //kullanıcı rolleri 
            IdentityResult result = new IdentityResult();
            List<string> applicationRoles = new List<string>();
            foreach (var deleteRole in request.RoleId)
            {
               var  deleteRoleUser = await _roleManager.FindByIdAsync(deleteRole);         
                if (deleteRoleUser != null)
                {
                    if (userRoles.Contains(deleteRoleUser.Name))
                    {
                        applicationRoles.Add(deleteRoleUser.Name);
                        result= await _userManager.RemoveFromRolesAsync(user, applicationRoles);
                    }
                }
            }
           
            if (result.Succeeded)
            {
                return Response.Success(200);
            }
            else
            {
                return Response.UnSuccess("Rol kaldırma işlemi başarısız", 404, true);
            }

        }
    }
}
