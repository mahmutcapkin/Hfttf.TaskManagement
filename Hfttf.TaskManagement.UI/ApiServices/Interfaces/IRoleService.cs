using Hfttf.TaskManagement.UI.Models.Role;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleResponse>> GetAllAsync();
        Task<RoleResponse> GetByIdAsync(string id);
        Task<bool> AddAsync(RoleAdd model);
        Task<bool> UpdateAsync(RoleUpdate model);
        Task<bool> DeleteAsync(string id);
        Task<bool> AssignRoleToUser(RoleAssignModel model);
        Task<bool> DeleteRoleToUser(RoleAssignModel model);
        Task<RoleResponse> GetRoleWithUsersById(string id);
    }
}
