using Hfttf.TaskManagement.Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Core.Entities
{
    public class Job : Entity
    {
        public string Name { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }

        public IList<ApplicationUser> ApplicationUsers { get; set; }
    }
}
