using Hfttf.TaskManagement.UI.Models.Holiday;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface ILeaveService
    {
        Task<List<LeaveResponse>> GetAllAsync();
        Task<LeaveResponse> GetByIdAsync(int id);
        Task AddAsync(LeaveAdd model);
        Task UpdateAsync(LeaveUpdate model);
        Task DeleteAsync(int id);
        Task<List<LeaveResponse>> GetListByUserId(string id);
    }
}
