using Hfttf.TaskManagement.Core.Entities;

namespace Hfttf.TaskManagement.Service.Services.TaskStatuses.Responses
{
    public class TaskStatusForTaskResponse
    {
        public int Id { get; set; }
        public StatusLevel Status { get; set; }
    }
}
