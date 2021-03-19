using Hfttf.TaskManagement.Core.Entities;
using System;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Service.Services.Tasks.Responses
{
    public class TaskResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime DueDate { get; set; }
        public sbyte Status { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public int TaskStatusId { get; set; }
        public virtual TaskStatus TaskStatus { get; set; }
        public IList<UserAssignment> UserAssignments { get; set; }
        public IList<TaskComment> TaskComments { get; set; }
        //public IList<TaskFile> TaskFiles { get; set; }
    }

  
}
