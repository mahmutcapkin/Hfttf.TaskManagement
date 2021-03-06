using Hfttf.TaskManagement.UI.Enums;
using Hfttf.TaskManagement.UI.Models.Task;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.UI.Models.TaskStatus
{
    public class TaskStatusResponse
    {
        public int Id { get; set; }
        public StatusLevel Status { get; set; }
        public List<TaskForTaskStatusResponse> Tasks { get; set; }
    }
}
