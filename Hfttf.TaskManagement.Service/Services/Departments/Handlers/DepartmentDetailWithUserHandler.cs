using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Departments.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Departments.Queries;
using Hfttf.TaskManagement.Service.Services.Departments.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Departments.Handlers
{
    public class DepartmentDetailWithUserHandler : BaseDepartmentHandler, IRequestHandler<DepartmentDetailWithUserQuery, Response>
    {
        public DepartmentDetailWithUserHandler(IDepartmentRepository departmentRepository) : base(departmentRepository)
        {
        }
        public async Task<Response> Handle(DepartmentDetailWithUserQuery request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetDepartmentWithUsers(request.Id);
            var response = TaskManagementMapper.Mapper.Map<DepartmentResponse>(department);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
