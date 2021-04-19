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
        public UserDeleteHandler(UserManager<ApplicationUser> userManager, IUserRepository userRepository) : base(userManager, userRepository)
        {
        }

        public async Task<Response> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            var getUser = await _userRepository.FindAsync(x => x.Id == request.Id);
            var user = TaskManagementMapper.Mapper.Map<ApplicationUser>(getUser);
            var result = await _userRepository.UpdateAsync(user);
            var userResponse = TaskManagementMapper.Mapper.Map<UserResponse>(result);
            var response = Response.Success(userResponse, 200);
            return response;
        }
    }
}
