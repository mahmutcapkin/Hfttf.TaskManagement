using System;

namespace Hfttf.TaskManagement.UI.Models.Holiday
{
    public class LeaveForUserResponse
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
    }
}
