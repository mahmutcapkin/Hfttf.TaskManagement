using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Tasks.Queries
{
    public class TaskDetailQuery : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
