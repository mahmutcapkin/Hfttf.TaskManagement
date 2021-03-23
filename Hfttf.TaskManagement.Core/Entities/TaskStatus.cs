using Hfttf.TaskManagement.Core.Entities.Base;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Core.Entities
{
    public class TaskStatus : Entity
    {
        public StatusLevel Status { get; set; }
        public IList<Task> Tasks { get; set; }

    }
    public enum StatusLevel
    {
        Pending=1,
        InProgress,
        OnHold,
        Cancelled
    }

}
