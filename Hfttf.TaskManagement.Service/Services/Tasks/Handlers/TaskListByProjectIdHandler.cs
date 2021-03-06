using Hfttf.TaskManagement.Core.Entities;
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
using Task = Hfttf.TaskManagement.Core.Entities.Task;

namespace Hfttf.TaskManagement.Service.Services.Tasks.Handlers
{
    public class TaskListByProjectIdHandler : BaseTaskHandler, IRequestHandler<TaskListByProjectIdQuery, Response>
    {
        public TaskListByProjectIdHandler(ITaskRepository taskRepository) : base(taskRepository)
        {

        }

        public async Task<Response> Handle(TaskListByProjectIdQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetListByProjectId(request.ProjectId);
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<TaskResponse>>(tasks);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
