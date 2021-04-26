using Hfttf.TaskManagement.UI.Models.Authentication;
using System;

namespace Hfttf.TaskManagement.UI.Models.UserAssignment
{
    public class UserAssignmentForTaskResponse
    {
        public int Id { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public AppUser ApplicationUser { get; set; }
        public int TaskId { get; set; }
    }
}
