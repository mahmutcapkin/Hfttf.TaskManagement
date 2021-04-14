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
    }
}
