using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Hfttf.TaskManagement.Service.Services.Users.Handlers.Base
{
    public class BaseUserHandler
    {
        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly RoleManager<ApplicationRole> _roleManager;
        protected readonly IUserRepository _userRepository;

        public BaseUserHandler(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IUserRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _roleManager = roleManager;
        }
    }
}
