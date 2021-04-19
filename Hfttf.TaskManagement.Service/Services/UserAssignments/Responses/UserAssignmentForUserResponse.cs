using Hfttf.TaskManagement.Service.Services.Tasks.Responses;
using System;

namespace Hfttf.TaskManagement.Service.Services.UserAssignments.Responses
{
    public class UserAssignmentForUserResponse
    {
        public int Id { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string ApplicationUserId { get; set; }
        public int TaskId { get; set; }
        public TaskResponse Task { get; set; }
    }
}
