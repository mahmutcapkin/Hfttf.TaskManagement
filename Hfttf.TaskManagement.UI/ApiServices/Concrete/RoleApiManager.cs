using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models.Role;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Concrete
{
    public class RoleApiManager : IRoleService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RoleApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Task AddAsync(RoleAdd model)
        {
            throw new NotImplementedException();
        }

        public Task AssignRoleToUser(string userId, List<string> roleId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRoleToUser(string userId, List<string> roleId)
        {
            throw new NotImplementedException();
        }

        public Task<List<RoleList>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RoleList> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(RoleUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
