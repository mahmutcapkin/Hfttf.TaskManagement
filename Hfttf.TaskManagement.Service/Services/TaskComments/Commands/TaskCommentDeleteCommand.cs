using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.TaskComments.Commands
{
    public class TaskCommentDeleteCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }

}
