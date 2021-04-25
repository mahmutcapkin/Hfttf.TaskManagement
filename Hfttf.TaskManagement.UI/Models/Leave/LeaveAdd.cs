using System;

namespace Hfttf.TaskManagement.UI.Models.Holiday
{
    public class LeaveAdd
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Day { get; set; }
        public bool IsActive { get; set; }
    }
}
