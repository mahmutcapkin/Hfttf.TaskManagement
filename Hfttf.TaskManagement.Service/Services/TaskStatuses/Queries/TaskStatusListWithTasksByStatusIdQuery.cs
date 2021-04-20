using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.TaskStatuses.Queries
{
    public class TaskStatusListWithTasksByStatusIdQuery : IRequest<Response>
    {
        public StatusLevel Status { get; set; }
    }
}
