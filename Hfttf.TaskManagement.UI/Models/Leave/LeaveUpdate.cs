using System;

namespace Hfttf.TaskManagement.UI.Models.Holiday
{
    public class LeaveUpdate
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string UpdateBy { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
