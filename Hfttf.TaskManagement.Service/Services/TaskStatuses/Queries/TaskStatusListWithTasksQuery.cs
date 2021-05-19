using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.TaskStatuses.Queries
{
    public class TaskStatusListWithTasksQuery : IRequest<Response>
    {
        public int ProjectId { get; set; }
    }
}
