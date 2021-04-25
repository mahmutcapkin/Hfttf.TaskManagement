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
    public class RoleInsertHandler : BaseRoleHandler, IRequestHandler<RoleInsertCommand, Response>
    {
        public RoleInsertHandler(RoleManager<ApplicationRole> roleManager, IRoleRepository roleRepository) : base(roleManager, roleRepository)
        {
        }

        public async Task<Response> Handle(RoleInsertCommand request, CancellationToken cancellationToken)
        {
            var role = TaskManagementMapper.Mapper.Map<ApplicationRole>(request);
            var response = await _roleManager.CreateAsync(role);

            if (response.Succeeded)
            {
                var roleMapping = TaskManagementMapper.Mapper.Map<RoleResponse>(role);
                var successResult = Response.Success(roleMapping, 200);
                return successResult;
            }
            var result = Response.UnSuccess("Rol Eklenemedi", 404, true);
            return result;
        }
    }
}
