using Hfttf.TaskManagement.UI.Models.Department;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentResponse>> GetAllAsync();
        Task<DepartmentResponse> GetByIdAsync(int id);      
        Task AddAsync(DepartmentAdd model);
        Task UpdateAsync(DepartmentUpdate model);
        Task<bool> DeleteAsync(int id);
        Task<List<DepartmentResponse>> GetListWithUsers();
        Task<DepartmentResponse> GetDepartmentWithUsersById(int id);
    }
}
