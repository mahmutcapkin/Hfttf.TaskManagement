using Hfttf.TaskManagement.UI.Enums;
using Hfttf.TaskManagement.UI.Models.Project;
using Hfttf.TaskManagement.UI.Models.TaskStatus;
using System;

namespace Hfttf.TaskManagement.UI.Models.Task
{
    public class TaskForUserAssignmentResponse
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
        public ProjectForTaskResponse Project { get; set; }
        public int TaskStatusId { get; set; }
        public TaskStatusForTaskResponse TaskStatus { get; set; }
    }
}
