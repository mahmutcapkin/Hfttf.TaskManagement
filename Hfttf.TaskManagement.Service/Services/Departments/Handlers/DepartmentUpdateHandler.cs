using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Departments.Commands;
using Hfttf.TaskManagement.Service.Services.Departments.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Departments.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Departments.Handlers
{
    public class DepartmentUpdateHandler : BaseDepartmentHandler, IRequestHandler<DepartmentUpdateCommand, Response>
    {
        public DepartmentUpdateHandler(IDepartmentRepository departmentRepository) : base(departmentRepository)
        {
        }
        public async Task<Response> Handle(DepartmentUpdateCommand request, CancellationToken cancellationToken)
        {
            var department = TaskManagementMapper.Mapper.Map<Department>(request);
            department.UpdatedDate = DateTime.Now;
            var departmentGetById = await _departmentRepository.GetByIdAsync(request.Id);
            department.CreatedDate = departmentGetById.CreatedDate;
            department.CreateBy = departmentGetById.CreateBy;
            var response = await _departmentRepository.UpdateAsync(department);
            var departmentResponse = TaskManagementMapper.Mapper.Map<DepartmentResponse>(response);
            var result = Response.Success(departmentResponse, 200);
            return result;
        }
    }
}
