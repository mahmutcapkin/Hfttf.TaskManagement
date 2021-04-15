using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Leaves.Commands
{
    public class LeaveDeleteCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
