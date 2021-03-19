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
    public class TaskStatusListHandler : BaseTaskStatusHandler, IRequestHandler<TaskStatusListQuery, Response>
    {
        public TaskStatusListHandler(ITaskStatusRepository taskStatusRepository):base(taskStatusRepository)
        {
        }

        public async Task<Response> Handle(TaskStatusListQuery request, CancellationToken cancellationToken)
        {
            var taskStatuses = await _taskStatusRepository.GetAllAsync();
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<TaskStatusResponse>>(taskStatuses);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
