using Hfttf.TaskManagement.Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Core.Entities
{
    public class Project : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public sbyte Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdateBy { get; set; }
        public byte IsActive { get; set; }
        //public IList<Leader> Leaders { get; set; }
        //public IList<ProjectTeam> ProjectTeams { get; set; }
        public IList<Task> Tasks { get; set; }

    }
}
