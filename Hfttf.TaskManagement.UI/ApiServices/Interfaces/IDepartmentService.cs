using Hfttf.TaskManagement.UI.Models.Department;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentList>> GetAllAsync();
        Task<DepartmentList> GetByIdAsync(int id);
        Task AddAsync(DepartmentAdd model);
        Task UpdateAsync(DepartmentUpdate model);
        Task DeleteAsync(int id);
    }
}
