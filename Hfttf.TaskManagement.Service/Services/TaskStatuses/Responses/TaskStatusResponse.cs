using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Service.Services.Tasks.Responses;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Service.Services.TaskStatuses.Responses
{
    public class TaskStatusResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StatusNameId { get; set; }
        public List<TaskForTaskStatusResponse> Tasks { get; set; }
    }
}
