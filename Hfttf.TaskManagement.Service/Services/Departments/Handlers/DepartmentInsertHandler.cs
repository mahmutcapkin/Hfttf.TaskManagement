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
    public class DepartmentInsertHandler : BaseDepartmentHandler, IRequestHandler<DepartmentInsertCommand, Response>
    {
        public DepartmentInsertHandler(IDepartmentRepository departmentRepository) : base(departmentRepository)
        {
        }
        public async Task<Response> Handle(DepartmentInsertCommand request, CancellationToken cancellationToken)
        {
            var department = TaskManagementMapper.Mapper.Map<Department>(request);
            department.CreatedDate = DateTime.Now;
            var response = await _departmentRepository.AddAsync(department);

            var departmentResponse = TaskManagementMapper.Mapper.Map<DepartmentResponse>(response);
            var result = Response.Success(departmentResponse, 200);
            return result;

        }
    }
}
