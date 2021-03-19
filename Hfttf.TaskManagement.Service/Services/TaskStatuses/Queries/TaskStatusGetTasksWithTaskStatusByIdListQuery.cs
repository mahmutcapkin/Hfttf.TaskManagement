using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.TaskStatuses.Queries
{
    public class TaskStatusGetTasksWithTaskStatusByIdListQuery : IRequest<Response>
    {
        public int StatusNameId { get; set; }
    }
}
