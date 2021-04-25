using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Core.ResourceViewModel;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Users.Commands;
using Hfttf.TaskManagement.Service.Services.Users.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Users.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApplicationUser = Hfttf.TaskManagement.Core.Entities.ApplicationUser;

namespace Hfttf.TaskManagement.Service.Services.Users.Handlers
{
    public class UserInsertHandler : BaseUserHandler, IRequestHandler<UserInsertCommand, Response>
    {
        public UserInsertHandler(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IUserRepository userRepository) : base(userManager, roleManager, userRepository)
        {
        }

        public async Task<Response> Handle(UserInsertCommand request, CancellationToken cancellationToken)
        {
            var userExist = await _userManager.FindByNameAsync(request.UserName);
            if (userExist != null)
            {
                return  Response.UnSuccess("Böyle bir kullanıcı adı mevcuttur",404,true);
            }

            var emailExist = await _userManager.FindByEmailAsync(request.Email);
            if (emailExist != null)
            {
                return Response.UnSuccess("Böyle bir email mevcuttur", 404, true);
            }
            var user = TaskManagementMapper.Mapper.Map<ApplicationUser>(request);
            //ApplicationUser user = new ApplicationUser
            //{
            //    UserName = request.UserName,
            //    Email = request.Email,
            //};
            IdentityResult result = await _userManager.CreateAsync(user, request.Password);
           
            if (result.Succeeded)
            {             
                if (await _roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await _userManager.AddToRolesAsync(user, new List<string>() { UserRoles.User });
                }
                var userResponse = TaskManagementMapper.Mapper.Map<UserResponse>(user);
                var userResult = Response.Success(userResponse, 200);
                return userResult;           
            }
            else
            {
                var errorResult = Response.UnSuccess("Kullanıcı eklenemedi", 404, true);
                return errorResult;
            }



          


        }
    }
}
