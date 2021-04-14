using Hfttf.TaskManagement.Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Core.Entities
{
    public class Project : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public PriorityLevel Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdateBy { get; set; }
        public int? LeaderId { get; set; }
        public Leader Leader { get; set; }
        public IList<ApplicationUser> ApplicationUsers { get; set; }
        public IList<Task> Tasks { get; set; }

    }
    public enum PriorityLevel
    {
        Highest = 1,
        High,
        Medium,
        Low,
        Lowest
    }
}
