using Hfttf.TaskManagement.UI.Models.Leader;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface ILeaderService
    {
        Task<List<LeaderList>> GetAllAsync();
        Task<LeaderList> GetByIdAsync(int id);
        Task AddAsync(LeaderAdd model);
        Task UpdateAsync(LeaderUpdate model);
        Task DeleteAsync(int id);
        Task<LeaderList> GetByIdWithProjectAndUser(int id);
        Task<LeaderList> GetByProjectIdandUserId(int projectId,string userId);
        Task<List<LeaderList>> GetListByProjectIdandUserId(int projectId, string userId);
        Task<List<LeaderList>> GetListByUserId(string id);
        Task<List<LeaderList>> GetListByProjectId(int id);
    }
}
