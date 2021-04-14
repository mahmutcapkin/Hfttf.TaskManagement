using Hfttf.TaskManagement.UI.Models.UserSalary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface IUserSalaryService
    {
        Task<List<UserSalaryList>> GetAllAsync();
        Task<UserSalaryList> GetByIdAsync(int id);
        Task AddAsync(UserSalaryAdd model);
        Task UpdateAsync(UserSalaryUpdate model);
        Task DeleteAsync(int id);
    }
}
