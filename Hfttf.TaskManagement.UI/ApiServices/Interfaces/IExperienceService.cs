using Hfttf.TaskManagement.UI.Models.Experience;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface IExperienceService
    {
        Task<List<ExperienceResponse>> GetAllAsync();
        Task<ExperienceResponse> GetByIdAsync(int id);
        Task AddAsync(ExperienceAdd model);
        Task UpdateAsync(ExperienceUpdate model);
        Task<bool> DeleteAsync(int id);
        Task<List<ExperienceResponse>> GetListByUserId(string id);
    }
}
