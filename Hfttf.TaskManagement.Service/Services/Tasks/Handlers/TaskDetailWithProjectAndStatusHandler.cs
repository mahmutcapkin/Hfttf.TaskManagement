using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Tasks.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Tasks.Queries;
using Hfttf.TaskManagement.Service.Services.Tasks.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Tasks.Handlers
{
    public class TaskDetailWithProjectAndStatusHandler : BaseTaskHandler, IRequestHandler<TaskDetailWithProjectAndStatusQuery, Response>
    {
        public TaskDetailWithProjectAndStatusHandler(ITaskRepository taskRepository) : base(taskRepository)
        {
        }
        public async Task<Response> Handle(TaskDetailWithProjectAndStatusQuery request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetTaskWithStatusAndProject(request.Id);
            var taskResponse = TaskManagementMapper.Mapper.Map<TaskResponse>(task);
            var response = Response.Success(taskResponse, 200);
            return response;
        }
    }
}
