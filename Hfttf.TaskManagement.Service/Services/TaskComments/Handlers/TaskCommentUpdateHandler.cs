using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.TaskComments.Commands;
using Hfttf.TaskManagement.Service.Services.TaskComments.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.TaskComments.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.TaskComments.Handlers
{
    public class TaskCommentUpdateHandler : BaseTaskCommentHandler, IRequestHandler<TaskCommentUpdateCommand, Response>
    {
        public TaskCommentUpdateHandler(ITaskCommentRepository taskCommentRepository) : base(taskCommentRepository)
        {
        }
        public async Task<Response> Handle(TaskCommentUpdateCommand request, CancellationToken cancellationToken)
        {
            var taskComment = TaskManagementMapper.Mapper.Map<TaskComment>(request);
            taskComment.UpdatedDate = DateTime.Now;
            var taskCommentGetById = await _taskCommentRepository.GetByIdAsync(request.Id);
            taskComment.CreatedDate = taskCommentGetById.CreatedDate;
            taskComment.CreateBy = taskCommentGetById.CreateBy;
            var response = await _taskCommentRepository.UpdateAsync(taskComment);
            var taskCommentResponse = TaskManagementMapper.Mapper.Map<TaskCommentResponse>(response);
            var result = Response.Success(taskCommentResponse, 200);
            return result;
        }
    }
}
