using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.TaskStatuses.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.TaskStatuses.Queries;
using Hfttf.TaskManagement.Service.Services.TaskStatuses.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.TaskStatuses.Handlers
{
    public class TaskStatusListWithTasksHandler : BaseTaskStatusHandler, IRequestHandler<TaskStatusListWithTasksQuery, Response>
    {
        public TaskStatusListWithTasksHandler(ITaskStatusRepository taskStatusRepository) : base(taskStatusRepository)
        {
        }

        public async Task<Response> Handle(TaskStatusListWithTasksQuery request, CancellationToken cancellationToken)
        {
            var taskStatuses = await _taskStatusRepository.GetTaskStatusesWithTasks(request.ProjectId);
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<TaskStatusResponse>>(taskStatuses);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
