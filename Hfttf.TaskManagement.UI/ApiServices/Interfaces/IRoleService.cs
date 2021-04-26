using Hfttf.TaskManagement.UI.Models.Role;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleResponse>> GetAllAsync();
        Task<RoleResponse> GetByIdAsync(string id);
        Task AddAsync(RoleAdd model);
        Task UpdateAsync(RoleUpdate model);
        Task DeleteAsync(string id);
        Task AssignRoleToUser(string userId, List<string> roleId);
        Task DeleteRoleToUser(string userId, List<string> roleId);
    }
}
