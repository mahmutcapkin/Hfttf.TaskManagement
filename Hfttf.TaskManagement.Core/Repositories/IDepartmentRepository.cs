using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Core.Repositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<IReadOnlyList<Department>> GetListWithUsers();
        Task<Department> GetDepartmentWithUsers(int id);
    }
}
