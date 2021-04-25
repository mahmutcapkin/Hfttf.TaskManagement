using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Roles.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Roles.Queries;
using Hfttf.TaskManagement.Service.Services.Roles.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Roles.Handlers
{
    public class RoleDetailHandler : BaseRoleHandler, IRequestHandler<RoleDetailQuery, Response>
    {
        public RoleDetailHandler(RoleManager<ApplicationRole> roleManager, IRoleRepository roleRepository) : base(roleManager, roleRepository)
        {
        }
        public async Task<Response> Handle(RoleDetailQuery request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(request.Id);
            if (role == null)
            {
                var unSuccesResult = Response.UnSuccess("Rol bulunamadı", 404, true);
                return unSuccesResult;

            }
            var response = TaskManagementMapper.Mapper.Map<RoleResponse>(role);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
