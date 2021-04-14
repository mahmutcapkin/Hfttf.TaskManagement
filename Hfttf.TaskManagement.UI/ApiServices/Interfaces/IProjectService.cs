using Hfttf.TaskManagement.UI.Models.Project;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface IProjectService
    {
        Task<List<ProjectList>> GetAllAsync();
        Task<ProjectList> GetByIdAsync(int id);
        Task AddAsync(ProjectAdd model);
        Task UpdateAsync(ProjectUpdate model);
        Task DeleteAsync(int id);
    }
}
