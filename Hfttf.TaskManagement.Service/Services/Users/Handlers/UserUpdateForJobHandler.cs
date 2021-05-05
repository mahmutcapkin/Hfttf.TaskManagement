using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Users.Commands;
using Hfttf.TaskManagement.Service.Services.Users.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Users.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Users.Handlers
{
    public class UserUpdateForJobHandler : BaseUserHandler, IRequestHandler<UserUpdateForJobCommand, Response>
    {
        public UserUpdateForJobHandler(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IUserRepository userRepository) : base(userManager, roleManager, userRepository)
        {
        }

        public async Task<Response> Handle(UserUpdateForJobCommand request, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByIdAsync(request.UserId);
            if (request.JobId == 0 || request.JobId == null)
            {
                user.JobId = null;
            }
            else
            {
                user.JobId = request.JobId;
            }

            IdentityResult result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                var userResponse = TaskManagementMapper.Mapper.Map<UserResponse>(user);
                var response = Response.Success(userResponse, 200);
                return response;
            }
            else
            {
                return Response.UnSuccess("Kullanıcı güncellenemedi", 400, true);
            }

        }
    }
}
