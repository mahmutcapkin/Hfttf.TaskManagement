using Hfttf.TaskManagement.Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Core.Entities
{
    public class Job : Entity
    {
        public string Name { get; set; }
        public IList<ApplicationUser> ApplicationUsers { get; set; }
    }
}
