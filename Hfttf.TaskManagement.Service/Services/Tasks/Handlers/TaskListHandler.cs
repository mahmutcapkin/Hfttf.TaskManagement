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
    public class TaskListHandler : BaseTaskHandler, IRequestHandler<TaskListQuery, Response>
    {
        public TaskListHandler(ITaskRepository taskRepository) : base(taskRepository)
        {
        }

        public async Task<Response> Handle(TaskListQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetAllAsync();
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<TaskResponse>>(tasks);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
