using Hfttf.TaskManagement.Core.Entities.Base;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Core.Entities
{
    public class Department : Entity
    {
        public string Name { get; set; }
        public IList<ApplicationUser> ApplicationUsers { get; set; }
    }
}
