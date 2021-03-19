using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Departments.Queries
{
    public class DepartmentDetailQuery : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
