using Hfttf.TaskManagement.UI.Models.UserAssignment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface IUserAssignmentService
    {
        Task<List<UserAssignmentList>> GetAllAsync();
        Task<UserAssignmentList> GetByIdAsync(int id);
        Task AddAsync(UserAssignmentAdd model);
        Task UpdateAsync(UserAssignmentUpdate model);
        Task DeleteAsync(int id);
        Task<List<UserAssignmentList>> GetListByUserId(string id);
    }
}
