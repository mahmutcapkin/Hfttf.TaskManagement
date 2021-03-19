using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.UserAssignments.Commands
{
    public class UserAssignmentDeleteCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}

