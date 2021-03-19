using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.UserAssignments.Queries
{
    public class UserAssignmentDetailQuery : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
