using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.TaskComments.Queries
{
  
    public class TaskCommentDetailQuery : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
