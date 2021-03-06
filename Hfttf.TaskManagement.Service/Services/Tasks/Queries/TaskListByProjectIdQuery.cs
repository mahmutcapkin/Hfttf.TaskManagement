using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Tasks.Queries
{
    public class TaskListByProjectIdQuery : IRequest<Response>
    {
        public int? ProjectId { get; set; }
    }
}
