using Hfttf.TaskManagement.UI.Models.Task;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.UI.Models.TaskStatus
{
    public class TaskStatusOperationModel
    {
        public List<TaskStatusResponse> TaskStatusResponses { get; set; }

        public TaskOperationModel TaskOperation { get; set; }
        public int ProjectId { get; set; }
    }
}
