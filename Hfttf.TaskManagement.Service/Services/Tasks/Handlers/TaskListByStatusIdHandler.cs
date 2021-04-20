using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Tasks.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Tasks.Queries;
using Hfttf.TaskManagement.Service.Services.Tasks.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Tasks.Handlers
{
    public class TaskListByStatusIdHandler : BaseTaskHandler, IRequestHandler<TaskListByStatusIdQuery, Response>
    {
        public TaskListByStatusIdHandler(ITaskRepository taskRepository) : base(taskRepository)
        {

        }

        public async Task<Response> Handle(TaskListByStatusIdQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetListByTaskStatusId(request.taskStatusId);
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<TaskResponse>>(tasks);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
