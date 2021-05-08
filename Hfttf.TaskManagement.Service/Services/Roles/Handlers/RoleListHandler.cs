using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
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
    public class RoleListHandler : BaseRoleHandler, IRequestHandler<RoleListQuery, Response>
    {
        public RoleListHandler(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager, IRoleRepository roleRepository) : base(roleManager, userManager, roleRepository)
        {
        }
        public async Task<Response> Handle(RoleListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<RoleResponse>>(roles);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
