using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Leaves.Queries
{
    public class LeaveListByUserIdQuery : IRequest<Response>
    {
        public string UserId { get; set; }
    }
}
