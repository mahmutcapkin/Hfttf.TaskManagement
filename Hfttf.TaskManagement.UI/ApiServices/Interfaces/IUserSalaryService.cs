using Hfttf.TaskManagement.UI.Models.UserSalary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface IUserSalaryService
    {
        Task<List<UserSalaryResponse>> GetAllAsync();
        Task<UserSalaryResponse> GetByIdAsync(int id);
        Task<bool> AddAsync(UserSalaryAdd model);
        Task<bool> UpdateAsync(UserSalaryUpdate model);
        Task<bool> DeleteAsync(int id);
        Task<List<UserSalaryResponse>> GetListByUserId(string id);
    }
}
