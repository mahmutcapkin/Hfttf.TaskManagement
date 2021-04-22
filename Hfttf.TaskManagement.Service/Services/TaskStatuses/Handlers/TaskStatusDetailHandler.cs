using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.TaskStatuses.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.TaskStatuses.Queries;
using Hfttf.TaskManagement.Service.Services.TaskStatuses.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.TaskStatuses.Handlers
{
    public class TaskStatusDetailHandler : BaseTaskStatusHandler, IRequestHandler<TaskStatusDetailQuery, Response>
    {
        public TaskStatusDetailHandler(ITaskStatusRepository taskRepository) : base(taskRepository)
        {
        }
        public async Task<Response> Handle(TaskStatusDetailQuery request, CancellationToken cancellationToken)
        {
            var taskStatus = await _taskStatusRepository.FindAsync(x=>x.Id==request.Id);
            var response = TaskManagementMapper.Mapper.Map<TaskStatusResponse>(taskStatus);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
