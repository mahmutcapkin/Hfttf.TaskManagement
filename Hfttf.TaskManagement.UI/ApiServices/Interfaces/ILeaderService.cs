using Hfttf.TaskManagement.UI.Models.Leader;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface ILeaderService
    {
        Task<List<LeaderResponse>> GetAllAsync();
        Task<LeaderResponse> GetByIdAsync(int id);
        Task<bool> AddAsync(LeaderAdd model);
        Task<bool> UpdateAsync(LeaderUpdate model);
        Task<bool> DeleteAsync(int id);
        Task<LeaderResponse> GetByIdWithProjectAndUser(int id);
        Task<LeaderResponse> GetByProjectIdandUserId(int projectId,string userId);
        Task<List<LeaderResponse>> GetListByProjectIdandUserId(int projectId, string userId);
        Task<List<LeaderResponse>> GetListByUserId(string id);
        Task<List<LeaderResponse>> GetListByProjectId(int id);
    }
}
