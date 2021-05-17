using Hfttf.TaskManagement.UI.Models.Project;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface IProjectService
    {
        Task<List<ProjectResponse>> GetAllAsync();
        Task<ProjectResponse> GetByIdAsync(int id);
        Task<bool> AddAsync(ProjectAdd model);
        Task<bool> UpdateAsync(ProjectUpdate model);
        Task<bool> DeleteAsync(int id);
        Task<List<ProjectResponse>> GetListWithTasksandUsers();
        Task<List<ProjectResponse>> GetListByUserId(string id);
        Task<ProjectResponse> GetProjectWithUserandTaskById(int id);
        Task<bool> ProjectDeleteUser(ProjectAssignUser model);
        Task<bool> ProjectAddUser(ProjectAssignUser model);
    }
}
