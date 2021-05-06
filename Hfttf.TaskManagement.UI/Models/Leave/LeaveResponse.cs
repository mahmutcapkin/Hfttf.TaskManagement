using Hfttf.TaskManagement.UI.Models.Authentication;
using Hfttf.TaskManagement.UI.Models.User;
using System;

namespace Hfttf.TaskManagement.UI.Models.Leave
{
    public class LeaveResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string NumberOfDay { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public string ApplicationUserId { get; set; }
        public UserResponse ApplicationUser { get; set; }
    }
}
