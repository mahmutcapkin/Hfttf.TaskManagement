using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Service.Services.Projects.Responses;
using Hfttf.TaskManagement.Service.Services.TaskStatuses.Responses;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Responses;
using System;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Service.Services.Tasks.Responses
{
    public class TaskResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public DateTime DueDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int? ProjectId { get; set; }
        public ProjectForTaskResponse Project { get; set; }
        public int TaskStatusId { get; set; }
        public TaskStatusForTaskResponse TaskStatus { get; set; }
        public IList<UserAssignmentForTaskResponse> UserAssignments { get; set; }
    }

  
}
