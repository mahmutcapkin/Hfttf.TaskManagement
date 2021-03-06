using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Service.Services.Leaders.Responses;
using Hfttf.TaskManagement.Service.Services.Tasks.Responses;
using System;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Service.Services.Projects.Responses
{
    public class ProjectForUserResponse
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
        public LeaderForProjectResponse Leader { get; set; }
        public IList<TaskForProjectResponse> Tasks { get; set; }
    }
}
