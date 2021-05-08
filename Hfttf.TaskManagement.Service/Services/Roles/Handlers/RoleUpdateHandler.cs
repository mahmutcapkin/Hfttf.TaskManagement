using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Roles.Commands;
using Hfttf.TaskManagement.Service.Services.Roles.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Roles.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Roles.Handlers
{
    public class RoleUpdateHandler : BaseRoleHandler, IRequestHandler<RoleUpdateCommand, Response>
    {
        public RoleUpdateHandler(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager, IRoleRepository roleRepository) : base(roleManager, userManager, roleRepository)
        {
        }
        public async Task<Response> Handle(RoleUpdateCommand request, CancellationToken cancellationToken)
        {         
            var role = await _roleManager.FindByIdAsync(request.Id);
            role.Name = request.Name;
            var response = await _roleManager.UpdateAsync(role);
            if(response.Succeeded)
            {
                var roleResponse = TaskManagementMapper.Mapper.Map<RoleResponse>(role);
                var roleResult = Response.Success(roleResponse, 200);
                return roleResult;
            }
            var result = Response.UnSuccess("Rol Güncellenemedi", 404,true);
            return result;
        }

    }
}
