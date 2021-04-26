using Hfttf.TaskManagement.UI.Models.Leader;
using Hfttf.TaskManagement.UI.Models.Task;
using System;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.UI.Models.Project
{
    public class ProjectForUserResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdateBy { get; set; }
        public LeaderForProjectResponse Leader { get; set; }
        public List<TaskForProjectResponse> Tasks { get; set; }
    }
}
