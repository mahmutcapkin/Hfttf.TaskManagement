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
using ApplicationUser = Hfttf.TaskManagement.Core.Entities.ApplicationUser;

namespace Hfttf.TaskManagement.Service.Services.Users.Handlers
{
    public class UserInsertHandler : BaseUserHandler, IRequestHandler<UserInsertCommand, Response>
    {
        public UserInsertHandler(UserManager<ApplicationUser> userManager, IUserRepository userRepository) : base(userManager, userRepository)
        {

        }

        public async Task<Response> Handle(UserInsertCommand request, CancellationToken cancellationToken)
        {
            var user = TaskManagementMapper.Mapper.Map<ApplicationUser>(request);
            var response = await  _userManager.CreateAsync(user,user.PasswordHash);
            
            if (response.Succeeded)
            {          
                var userResponse = await _userManager.FindByEmailAsync(request.Email);
                var userMapping = TaskManagementMapper.Mapper.Map<UserResponse>(userResponse);
                var successResult = Response.Success(userMapping, 200);
                return successResult;
            }
  
            var result = Response.UnSuccess(response.ToString(), 404,true);
            return result;
        }
    }
}
