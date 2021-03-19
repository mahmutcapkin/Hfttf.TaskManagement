using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Tasks.Commands
{
    public class TaskDeleteCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
