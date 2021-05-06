using Hfttf.TaskManagement.UI.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface IUserService
    {
        Task<List<UserResponse>> GetAllAsync();
        Task<UserResponse> GetByIdAsync(string id);
        Task<bool> AddAsync(UserAdd model);
        Task<bool> UpdateAsync(UserUpdate model);
        Task<bool> UpdateForDepartmentAsync(UpdateForDepartment model);
        Task<bool> UpdateForJobAsync(UpdateForJob model);
        Task<bool> DeleteAsync(string id);
        Task<UserResponse> GetByIdWithInfo(string id);
        Task<List<UserResponse>> GetListWithInfo(string id);
    }
}
