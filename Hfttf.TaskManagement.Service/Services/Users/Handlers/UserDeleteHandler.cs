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
    public class UserDeleteHandler : BaseUserHandler, IRequestHandler<UserDeleteCommand, Response>
    {
        public UserDeleteHandler(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IUserRepository userRepository) : base(userManager,roleManager, userRepository)
        {
        }

        public async Task<Response> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            var userType = await _userManager.FindByIdAsync(request.Id);
            var user = TaskManagementMapper.Mapper.Map<ApplicationUser>(userType);
            IdentityResult result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                var userResponse = TaskManagementMapper.Mapper.Map<UserResponse>(user);
                var response = Response.Success(userResponse, 200);
                return response;
            }
            else
            {
                return Response.UnSuccess("Kullanıcı Silinemedi", 404, true);
            }      

        }
    }
}
