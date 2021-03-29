using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.ResourceViewModel;
using System;

namespace Hfttf.TaskManagement.Service.Services.UserAssignments.Responses
{
    public class UserAssignmentResponse
    {
        public int Id { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public UserViewResponse ApplicationUser { get; set; }
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }
    }
}
