using Hfttf.TaskManagement.UI.Models.Leave;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface ILeaveService
    {
        Task<List<LeaveResponse>> GetAllAsync();
        Task<LeaveResponse> GetByIdAsync(int id);
        Task<bool> AddAsync(LeaveAdd model);
        Task<bool> UpdateAsync(LeaveUpdate model);
        Task<bool> DeleteAsync(int id);
        Task<List<LeaveResponse>> GetListByUserId(string id);
    }
}
