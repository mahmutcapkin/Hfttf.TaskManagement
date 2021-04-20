using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.UserAssignments.Queries
{
    public class UserAssignmentListByUserIdQuery : IRequest<Response>
    {
        public string UserId { get; set; }
    }
}
