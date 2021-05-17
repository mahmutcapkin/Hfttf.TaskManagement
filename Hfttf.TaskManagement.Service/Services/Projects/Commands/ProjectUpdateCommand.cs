using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using MediatR;
using System;

namespace Hfttf.TaskManagement.Service.Services.Projects.Commands
{
    public class ProjectUpdateCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public PriorityLevel Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string UpdateBy { get; set; }
        public int? LeaderId { get; set; }
    }
}
