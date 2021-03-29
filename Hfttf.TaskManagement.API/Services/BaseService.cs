using Hfttf.TaskManagement.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hfttf.TaskManagement.API.Services
{
    public class BaseService : ControllerBase
    {
        protected UserManager<ApplicationUser> userManager { get; }
        protected SignInManager<ApplicationUser> signInManager { get; }
        protected RoleManager<ApplicationRole> roleManager { get; }

        public BaseService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;

        }


    }
}
