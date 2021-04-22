using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.TaskStatuses.Queries
{
    public class TaskStatusWithTasksByStatusIdQuery : IRequest<Response>
    {
        public int Status { get; set; }
    }
}
