using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Departments.Commands
{
    public class DepartmentInsertCommand : IRequest<Response>
    {
        public string Name { get; set; }
    }
}
