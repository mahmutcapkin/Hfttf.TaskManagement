using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.TaskStatuses.Queries
{
    public class TaskStatusDetailQuery : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
