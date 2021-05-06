using Hfttf.TaskManagement.UI.Models.UserAssignment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface IUserAssignmentService
    {
        Task<List<UserAssignmentResponse>> GetAllAsync();
        Task<UserAssignmentResponse> GetByIdAsync(int id);
        Task<bool> AddAsync(UserAssignmentAdd model);
        Task<bool> UpdateAsync(UserAssignmentUpdate model);
        Task<bool> DeleteAsync(int id);
        Task<List<UserAssignmentResponse>> GetListByUserId(string id);
    }
}
