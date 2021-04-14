using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.TaskStatuses.Commands
{
    public class TaskStatusInsertCommand : IRequest<Response>
    {
        public int Status { get; set; }
    }
}
