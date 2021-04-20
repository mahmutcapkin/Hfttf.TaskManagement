using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Departments.Queries
{
    public class DepartmentDetailWithUserQuery : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
