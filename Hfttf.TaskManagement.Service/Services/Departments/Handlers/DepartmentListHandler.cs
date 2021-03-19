using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Departments.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Departments.Queries;
using Hfttf.TaskManagement.Service.Services.Departments.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Departments.Handlers
{
    public class DepartmentListHandler : BaseDepartmentHandler, IRequestHandler<DepartmentListQuery, Response>
    {
        public DepartmentListHandler(IDepartmentRepository departmentRepository) : base(departmentRepository)
        {
        }
        public async Task<Response> Handle(DepartmentListQuery request, CancellationToken cancellationToken)
        {
            var shiftType = await _departmentRepository.GetAllAsync();
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<DepartmentResponse>>(shiftType);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
