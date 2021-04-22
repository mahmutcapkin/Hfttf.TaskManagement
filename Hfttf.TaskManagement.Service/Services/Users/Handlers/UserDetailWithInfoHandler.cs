using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Users.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Users.Queries;
using Hfttf.TaskManagement.Service.Services.Users.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Users.Handlers
{
    public class UserDetailWithInfoHandler : BaseUserHandler, IRequestHandler<UserDetailWithInfoQuery, Response>
    {
        public UserDetailWithInfoHandler(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IUserRepository userRepository) : base(userManager, roleManager, userRepository)
        {
        }

        public async Task<Response> Handle(UserDetailWithInfoQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserDetailById(request.Id);
            if (user == null)
            {
                var unSuccesResult = Response.UnSuccess("User Not Found!", 404, false);
                return unSuccesResult;

            }
            var response = TaskManagementMapper.Mapper.Map<UserResponse>(user);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
