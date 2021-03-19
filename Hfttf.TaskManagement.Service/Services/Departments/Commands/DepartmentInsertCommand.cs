using Hfttf.TaskManagement.Core.Models;
using MediatR;
using System;

namespace Hfttf.TaskManagement.Service.Services.Departments.Commands
{
    public class DepartmentInsertCommand : IRequest<Response>
    {
        public string Name { get; set; }
        public string CreateBy { get; set; }
        public bool IsActive { get; set; }
    }
}
