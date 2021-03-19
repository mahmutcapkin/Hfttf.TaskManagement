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
    public class DepartmentDetailHandler : BaseDepartmentHandler, IRequestHandler<DepartmentDetailQuery, Response>
    {
        public DepartmentDetailHandler(IDepartmentRepository departmentRepository) : base(departmentRepository)
        {
        }
        public async Task<Response> Handle(DepartmentDetailQuery request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.FindAsync(x => x.Id == request.Id);
            var response = TaskManagementMapper.Mapper.Map<DepartmentResponse>(department);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
