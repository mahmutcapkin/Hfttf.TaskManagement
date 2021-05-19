using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.UserAssignments.Queries
{
    public class UserAssignmentListByProjectIdQuery : IRequest<Response>
    {
        public int ProjectId { get; set; }
    }
}
