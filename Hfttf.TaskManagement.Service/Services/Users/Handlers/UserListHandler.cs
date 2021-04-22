using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Users.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Users.Queries;
using Hfttf.TaskManagement.Service.Services.Users.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Users.Handlers
{
    public class UserListHandler : BaseUserHandler, IRequestHandler<UserListQuery, Response>
    {
        public UserListHandler(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IUserRepository userRepository) : base(userManager, roleManager, userRepository)
        {
        }

        public async Task<Response> Handle(UserListQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.ToListAsync();
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<UserResponse>>(user);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
