using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Departments.Commands
{
    public class DepartmentUpdateCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
