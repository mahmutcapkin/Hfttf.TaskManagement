using Hfttf.TaskManagement.Service.Services.Tasks.Responses;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Service.Services.TaskStatuses.Responses
{
    public class TaskStatusResponse
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public IList<TaskForTaskStatusResponse> Tasks { get; set; }
    }
}
