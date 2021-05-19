using Hfttf.TaskManagement.UI.Enums;
using System;

namespace Hfttf.TaskManagement.UI.Models.Task
{
    public class TaskUpdate
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public PriorityLevel Priority { get; set; }
        public DateTime DueDate { get; set; }
        public string UpdateBy { get; set; }
        public int ProjectId { get; set; }
        public int TaskStatusId { get; set; }
    }
}
