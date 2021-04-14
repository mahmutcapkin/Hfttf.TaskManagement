using System;

namespace Hfttf.TaskManagement.UI.Models.UserAssignment
{
    public class UserAssignmentList
    {
        public int Id { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public string ApplicationUserId { get; set; }
        public int TaskId { get; set; }
    }
}
