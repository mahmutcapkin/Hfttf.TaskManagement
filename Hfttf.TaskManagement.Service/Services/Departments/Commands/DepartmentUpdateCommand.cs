using Hfttf.TaskManagement.Core.Models;
using MediatR;
using System;

namespace Hfttf.TaskManagement.Service.Services.Departments.Commands
{
    public class DepartmentUpdateCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UpdateBy { get; set; }
        public bool IsActive { get; set; }

    }
}
