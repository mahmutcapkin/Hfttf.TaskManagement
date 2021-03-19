using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Departments.Commands;
using Hfttf.TaskManagement.Service.Services.Departments.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Departments.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Departments.Handlers
{
    public class DepartmentDeleteHandler : BaseDepartmentHandler, IRequestHandler<DepartmentDeleteCommand, Response>
    {
        public DepartmentDeleteHandler(IDepartmentRepository departmentRepository) : base(departmentRepository)
        {
        }
        public async Task<Response> Handle(DepartmentDeleteCommand request, CancellationToken cancellationToken)
        {
            var department = TaskManagementMapper.Mapper.Map<Department>(request);
            var response = await _departmentRepository.DeleteAsync(department);
            var departmentResponse = TaskManagementMapper.Mapper.Map<DepartmentResponse>(response);
            var result = Response.Success(departmentResponse, 200);
            return result;

        }
    }
}
