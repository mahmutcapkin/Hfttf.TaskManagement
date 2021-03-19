using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.TaskComments.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.TaskComments.Queries;
using Hfttf.TaskManagement.Service.Services.TaskComments.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.TaskComments.Handlers
{
    public class TaskCommentListHandler : BaseTaskCommentHandler, IRequestHandler<TaskCommentListQuery, Response>
    {
        public TaskCommentListHandler(ITaskCommentRepository taskCommentRepository) : base(taskCommentRepository)
        {
        }

        public async Task<Response> Handle(TaskCommentListQuery request, CancellationToken cancellationToken)
        {
            var taskComments = await _taskCommentRepository.GetAllAsync();
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<TaskCommentResponse>>(taskComments);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
