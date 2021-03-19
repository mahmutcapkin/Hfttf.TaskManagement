using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.TaskComments.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.TaskComments.Queries;
using Hfttf.TaskManagement.Service.Services.TaskComments.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.TaskComments.Handlers
{
    public class TaskCommentDetailHandler : BaseTaskCommentHandler, IRequestHandler<TaskCommentDetailQuery, Response>
    {
        public TaskCommentDetailHandler(ITaskCommentRepository taskCommentRepository) : base(taskCommentRepository)
        {
        }
        public async Task<Response> Handle(TaskCommentDetailQuery request, CancellationToken cancellationToken)
        {
            var taskComment = await _taskCommentRepository.FindAsync(x => x.Id == request.Id);
            var taskCommentResponse = TaskManagementMapper.Mapper.Map<TaskCommentResponse>(taskComment);
            var response = Response.Success(taskCommentResponse, 200);
            return response;
        }
    }
}
