using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Tasks.Commands;
using Hfttf.TaskManagement.Service.Services.Tasks.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Tasks.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Task = Hfttf.TaskManagement.Core.Entities.Task;

namespace Hfttf.TaskManagement.Service.Services.Tasks.Handlers
{
    public class TaskUpdateHandler : BaseTaskHandler, IRequestHandler<TaskUpdateCommand, Response>
    {
        public TaskUpdateHandler(ITaskRepository taskRepository) : base(taskRepository)
        {
        }
        public async Task<Response> Handle(TaskUpdateCommand request, CancellationToken cancellationToken)
        {
            var task = TaskManagementMapper.Mapper.Map<Task>(request);
            task.UpdatedDate = DateTime.Now;
            var taskGetById = await _taskRepository.GetByIdAsync(request.Id);
            task.CreatedDate = taskGetById.CreatedDate;
            task.CreateBy = taskGetById.CreateBy;
            var response = await _taskRepository.UpdateAsync(task);
            var taskResponse = TaskManagementMapper.Mapper.Map<TaskResponse>(response);
            var result = Response.Success(taskResponse, 200);
            return result;
        }
    }
}
