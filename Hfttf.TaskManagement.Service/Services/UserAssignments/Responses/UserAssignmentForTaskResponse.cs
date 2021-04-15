using Hfttf.TaskManagement.Core.ResourceViewModel;
using System;

namespace Hfttf.TaskManagement.Service.Services.UserAssignments.Responses
{
    public class UserAssignmentForTaskResponse
    {
        public int Id { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public UserViewResponse ApplicationUser { get; set; }
        public int TaskId { get; set; }
    }
}
