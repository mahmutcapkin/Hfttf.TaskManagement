using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.TaskStatuses.Commands
{
    public class TaskStatusUpdateCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public int Status { get; set; }
    }
}
