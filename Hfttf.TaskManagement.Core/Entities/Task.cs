using Hfttf.TaskManagement.Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Core.Entities
{
    public class Task : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public PriorityLevel Priority { get; set; }
        public DateTime DueDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public int TaskStatusId { get; set; }
        public virtual TaskStatus TaskStatus { get; set; }
        public IList<UserAssignment> UserAssignments { get; set; }
    }

}
