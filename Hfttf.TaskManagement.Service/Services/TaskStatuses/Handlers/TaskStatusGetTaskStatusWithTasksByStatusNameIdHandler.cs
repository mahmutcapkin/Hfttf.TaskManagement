using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.TaskStatuses.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.TaskStatuses.Queries;
using Hfttf.TaskManagement.Service.Services.TaskStatuses.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.TaskStatuses.Handlers
{
    public class TaskStatusGetTaskStatusWithTasksByStatusNameIdHandler : BaseTaskStatusHandler, IRequestHandler<TaskStatusGetTasksWithTaskStatusByIdListQuery, Response>
    {

        public TaskStatusGetTaskStatusWithTasksByStatusNameIdHandler(ITaskStatusRepository taskStatusRepository) : base(taskStatusRepository)
        {
        }
        public async Task<Response> Handle(TaskStatusGetTasksWithTaskStatusByIdListQuery request, CancellationToken cancellationToken)
        {
            var taskStatus = await _taskStatusRepository.GetTaskStatusWithTasksByStatusNameId(request.StatusNameId);
            var response = TaskManagementMapper.Mapper.Map<TaskStatusResponse>(taskStatus);
            var result = Response.Success(response, 200);
            return result;
        }

    }
}
