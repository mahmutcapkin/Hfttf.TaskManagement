using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using MediatR;
using System;

namespace Hfttf.TaskManagement.Service.Services.Tasks.Commands
{
    public class TaskUpdateCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public PriorityLevel Priority { get; set; }
        public DateTime DueDate { get; set; }
        public string UpdateBy { get; set; }
        public int ProjectId { get; set; }
        public int TaskStatusId { get; set; }

    }
}
