using Hfttf.TaskManagement.Service.Services.Tasks.Responses;
using Hfttf.TaskManagement.Service.Services.Users.Responses;
using System;

namespace Hfttf.TaskManagement.Service.Services.UserAssignments.Responses
{
    public class UserAssignmentResponse
    {
        public int Id { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string ApplicationUserId { get; set; }
        public UserViewResponse ApplicationUser { get; set; }
        public int TaskId { get; set; }
        public TaskForUserAssignmentResponse Task { get; set; }
    }
}
