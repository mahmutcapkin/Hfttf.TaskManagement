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
    public class TaskStatusWithTasksByStatusIdHandler : BaseTaskStatusHandler, IRequestHandler<TaskStatusListWithTasksByStatusIdQuery, Response>
    {

        public TaskStatusWithTasksByStatusIdHandler(ITaskStatusRepository taskStatusRepository) : base(taskStatusRepository)
        {
        }
        public async Task<Response> Handle(TaskStatusListWithTasksByStatusIdQuery request, CancellationToken cancellationToken)
        {
            var taskStatus = await _taskStatusRepository.GetTaskStatusWithTasksByStatusId(request.Status);
            var response = TaskManagementMapper.Mapper.Map<TaskStatusResponse>(taskStatus);
            var result = Response.Success(response, 200);
            return result;
        }

    }
}
