using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Hfttf.TaskManagement.Service.Services.Roles.Handlers.Base
{
    public class BaseRoleHandler
    {
        protected readonly RoleManager<ApplicationRole> _roleManager;
        protected readonly IRoleRepository _roleRepository;
        public BaseRoleHandler(RoleManager<ApplicationRole> roleManager, IRoleRepository roleRepository)
        {
            _roleManager = roleManager;
            _roleRepository = roleRepository;
        }
    }
}
