using Hfttf.TaskManagement.UI.Enums;
using System;

namespace Hfttf.TaskManagement.UI.Models.Task
{
    public class TaskForTaskStatusResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public PriorityLevel Priority { get; set; }
        public DateTime DueDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int ProjectId { get; set; }
        public int TaskStatusId { get; set; }
    }
}
