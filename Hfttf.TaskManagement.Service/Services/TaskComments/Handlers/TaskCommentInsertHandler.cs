using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.TaskComments.Commands;
using Hfttf.TaskManagement.Service.Services.TaskComments.Handlers.Base;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Hfttf.TaskManagement.Service.Services.TaskComments.Responses;
using System;

namespace Hfttf.TaskManagement.Service.Services.TaskComments.Handlers
{
    public class TaskCommentInsertHandler : BaseTaskCommentHandler, IRequestHandler<TaskCommentInsertCommand, Response>
    {

        public TaskCommentInsertHandler(ITaskCommentRepository taskCommentRepository) : base(taskCommentRepository)
        {
        }
        public async Task<Core.Models.Response> Handle(TaskCommentInsertCommand request, CancellationToken cancellationToken)
        {
            var taskComment = TaskManagementMapper.Mapper.Map<TaskComment>(request);
            taskComment.CreatedDate = DateTime.Now;
            var response = await _taskCommentRepository.AddAsync(taskComment);

            var taskCommentResponse = TaskManagementMapper.Mapper.Map<TaskCommentResponse>(response);
            var result = Response.Success(taskCommentResponse, 200);
            return result;

        }
    }
}
