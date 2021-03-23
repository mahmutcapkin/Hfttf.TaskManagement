﻿using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.TaskComments.Commands;
using Hfttf.TaskManagement.Service.Services.TaskComments.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.TaskComments.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.TaskComments.Handlers
{
    public class TaskCommentDeleteHandler : BaseTaskCommentHandler, IRequestHandler<TaskCommentDeleteCommand, Response>
    {
        public TaskCommentDeleteHandler(ITaskCommentRepository taskCommentRepository) : base(taskCommentRepository)
        {
        }
        public async Task<Response> Handle(TaskCommentDeleteCommand request, CancellationToken cancellationToken)
        {
            var taskComment = TaskManagementMapper.Mapper.Map<TaskComment>(request);
            var response = await _taskCommentRepository.DeleteAsync(taskComment);
            var taskCommentResponse = TaskManagementMapper.Mapper.Map<TaskCommentResponse>(response);
            var result = Response.Success(taskCommentResponse, 200);
            return result;
        }
    }
}