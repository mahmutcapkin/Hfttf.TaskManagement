using Hfttf.TaskManagement.UI.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface IUserService
    {
        Task<List<UserResponse>> GetAllAsync();
        Task<UserResponse> GetByIdAsync(string id);
        Task AddAsync(UserAdd model);
        Task UpdateAsync(UserUpdate model);
        Task DeleteAsync(string id);
        Task<UserResponse> GetByIdWithInfo(string id);
        Task<List<UserResponse>> GetListWithInfo(string id);
    }
}
