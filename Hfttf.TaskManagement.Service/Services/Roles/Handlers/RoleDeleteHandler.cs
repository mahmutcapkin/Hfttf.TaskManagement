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
    public class RoleDeleteHandler : BaseRoleHandler, IRequestHandler<RoleDeleteCommand, Response>
    {
        public RoleDeleteHandler(RoleManager<ApplicationRole> roleManager,IRoleRepository roleRepository) : base(roleManager,roleRepository)
        {
        }
        public async Task<Response> Handle(RoleDeleteCommand request, CancellationToken cancellationToken)
        {         
            var role = await _roleManager.FindByIdAsync(request.Id);
            var response = await _roleManager.DeleteAsync(role);
            if (response.Succeeded)
            {
                var roleResponse = TaskManagementMapper.Mapper.Map<RoleResponse>(role);
                var roleResult = Response.Success(roleResponse, 200);
                return roleResult;
            }
            var result = Response.UnSuccess("Role silinemedi",404,true);
            return result;
        }
    }
}
