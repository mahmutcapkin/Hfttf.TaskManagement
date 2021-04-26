using System;

namespace Hfttf.TaskManagement.UI.Models.Project
{
    public class ProjectUpdate
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string UpdateBy { get; set; }
        public int? LeaderId { get; set; }
    }
}
