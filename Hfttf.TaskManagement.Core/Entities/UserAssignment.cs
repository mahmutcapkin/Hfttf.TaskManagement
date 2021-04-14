using Hfttf.TaskManagement.Core.Entities.Base;
using System;

namespace Hfttf.TaskManagement.Core.Entities
{
    public class UserAssignment : Entity
    {
        public string CreateBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }
    }
}
