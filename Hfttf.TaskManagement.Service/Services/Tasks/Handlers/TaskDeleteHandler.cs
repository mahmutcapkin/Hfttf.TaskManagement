using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Tasks.Commands;
using Hfttf.TaskManagement.Service.Services.Tasks.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Tasks.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Task = Hfttf.TaskManagement.Core.Entities.Task;

namespace Hfttf.TaskManagement.Service.Services.Tasks.Handlers
{
    public class TaskDeleteHandler : BaseTaskHandler, IRequestHandler<TaskDeleteCommand, Response>
    {
        public TaskDeleteHandler(ITaskRepository taskRepository) : base(taskRepository)
        {
        }
        public async Task<Response> Handle(TaskDeleteCommand request, CancellationToken cancellationToken)
        {
            var task = TaskManagementMapper.Mapper.Map<Task>(request);
            var response = await _taskRepository.DeleteAsync(task);
            var taskResponse = TaskManagementMapper.Mapper.Map<TaskResponse>(response);
            var result = Response.Success(taskResponse, 200);
            return result;
        }
    }
}
