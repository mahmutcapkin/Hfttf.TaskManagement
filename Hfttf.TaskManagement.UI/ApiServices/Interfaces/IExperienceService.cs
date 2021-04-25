using Hfttf.TaskManagement.UI.Models.Experience;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface IExperienceService
    {
        Task<List<ExperienceList>> GetAllAsync();
        Task<ExperienceList> GetByIdAsync(int id);
        Task AddAsync(ExperienceAdd model);
        Task UpdateAsync(ExperienceUpdate model);
        Task DeleteAsync(int id);
        Task<List<ExperienceList>> GetListByUserId(string id);
    }
}
