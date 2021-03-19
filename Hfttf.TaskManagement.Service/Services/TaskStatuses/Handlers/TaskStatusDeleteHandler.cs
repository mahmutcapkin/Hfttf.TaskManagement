using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.TaskStatuses.Commands;
using Hfttf.TaskManagement.Service.Services.TaskStatuses.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.TaskStatuses.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskStatus = Hfttf.TaskManagement.Core.Entities.TaskStatus;

namespace Hfttf.TaskManagement.Service.Services.TaskStatuses.Handlers
{
    public class TaskStatusDeleteHandler : BaseTaskStatusHandler, IRequestHandler<TaskStatusDeleteCommand, Response>
    {
        public TaskStatusDeleteHandler(ITaskStatusRepository taskRepository) : base(taskRepository)
        {
        }
        public async Task<Response> Handle(TaskStatusDeleteCommand request, CancellationToken cancellationToken)
        {
            var taskStatus = TaskManagementMapper.Mapper.Map<TaskStatus>(request);
            var response = await _taskStatusRepository.DeleteAsync(taskStatus);
            var taskStatusResponse = TaskManagementMapper.Mapper.Map<TaskStatusResponse>(response);
            var result = Response.Success(taskStatusResponse, 200);
            return result;
        }
    }
}
