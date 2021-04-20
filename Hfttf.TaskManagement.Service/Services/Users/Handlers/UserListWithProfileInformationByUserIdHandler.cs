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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Users.Handlers
{
    public class UserListWithProfileInformationByUserIdHandler : BaseUserHandler, IRequestHandler<UserGetUsersWithProfileInformationByUserIdQuery, Response>
    {
        public UserListWithProfileInformationByUserIdHandler(UserManager<ApplicationUser> userManager, IUserRepository userRepository) : base(userManager, userRepository)
        {
        }

        public async Task<Response> Handle(UserGetUsersWithProfileInformationByUserIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.Include(x => x.EmergencyContactInfos.Where(x => x.ApplicationUserId == request.UserId))
                .Include(x => x.Experiences.Where(x => x.ApplicationUserId == request.UserId))
                .Include(x => x.EducationInformations.Where(x => x.ApplicationUserId == request.UserId))
                .Include(x => x.BankInformations.Where(x=>x.ApplicationUserId==request.UserId))
                .Include(x=>x.Addresses)
                .Include(x=>x.Job)
                .FirstOrDefaultAsync(x => x.Id == request.UserId);

            var response = TaskManagementMapper.Mapper.Map<UserResponse>(user);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
