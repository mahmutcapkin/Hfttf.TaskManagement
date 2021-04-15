using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Leaves.Queries
{
    public class LeaveDetailQuery : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
