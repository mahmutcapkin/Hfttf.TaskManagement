using Hfttf.TaskManagement.Core.Entities.Base;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Core.Entities
{
    public class TaskStatus : Entity
    {
        public string Name { get; set; }
        public int StatusNameId { get; set; }
        public IList<Task> Tasks { get; set; }

    }

}
