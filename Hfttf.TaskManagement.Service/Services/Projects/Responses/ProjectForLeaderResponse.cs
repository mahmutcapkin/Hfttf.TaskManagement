using Hfttf.TaskManagement.Core.Entities;
using System;

namespace Hfttf.TaskManagement.Service.Services.Projects.Responses
{
    public class ProjectForLeaderResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public PriorityLevel Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdateBy { get; set; }
    }
}
