using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Tasks.Queries
{
    public class TaskListByStatusIdQuery : IRequest<Response>
    {
        public int taskStatusId { get; set; }
    }
}
