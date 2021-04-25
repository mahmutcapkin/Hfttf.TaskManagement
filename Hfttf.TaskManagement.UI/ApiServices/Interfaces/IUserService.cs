using Hfttf.TaskManagement.UI.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface IUserService
    {
        Task<List<UserList>> GetAllAsync();
        Task<UserList> GetByIdAsync(string id);
        Task AddAsync(UserAdd model);
        Task UpdateAsync(UserUpdate model);
        Task DeleteAsync(string id);
        Task<UserList> GetByIdWithInfo(string id);
        Task<List<UserList>> GetListWithInfo(string id);
    }
}
