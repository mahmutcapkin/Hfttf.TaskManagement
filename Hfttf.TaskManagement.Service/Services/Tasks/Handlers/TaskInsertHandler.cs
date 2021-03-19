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
    public class TaskInsertHandler : BaseTaskHandler, IRequestHandler<TaskInsertCommand, Response>
    {

        public TaskInsertHandler(ITaskRepository taskRepository) : base(taskRepository)
        {
        }
        public async Task<Core.Models.Response> Handle(TaskInsertCommand request, CancellationToken cancellationToken)
        {
            var task = TaskManagementMapper.Mapper.Map<Task>(request);
            task.CreatedDate = DateTime.Now;
            var response = await _taskRepository.AddAsync(task);
            var taskResponse = TaskManagementMapper.Mapper.Map<TaskResponse>(response);
            var result = Response.Success(taskResponse, 200);
            return result;

        }
    }
}
