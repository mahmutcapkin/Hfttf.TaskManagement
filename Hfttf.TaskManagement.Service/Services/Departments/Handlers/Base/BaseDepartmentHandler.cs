using Hfttf.TaskManagement.Core.Repositories;

namespace Hfttf.TaskManagement.Service.Services.Departments.Handlers.Base
{
    public class BaseDepartmentHandler
    {
        protected readonly IDepartmentRepository _departmentRepository;

        public BaseDepartmentHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
    }
}
