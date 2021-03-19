using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.TaskStatuses.Commands
{
    public class TaskStatusDeleteCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
