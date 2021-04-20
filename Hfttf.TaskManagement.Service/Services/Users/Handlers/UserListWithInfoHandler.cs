using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Users.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Users.Queries;
using Hfttf.TaskManagement.Service.Services.Users.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Users.Handlers
{
    public class UserListWithInfoHandler : BaseUserHandler, IRequestHandler<UserListWithInfoQuery, Response>
    {
        public UserListWithInfoHandler(UserManager<ApplicationUser> userManager, IUserRepository userRepository) : base(userManager, userRepository)
        {
        }

        public async Task<Response> Handle(UserListWithInfoQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserList();
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<UserResponse>>(user);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
