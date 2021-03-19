using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Departments.Commands
{
    public class DepartmentDeleteCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
