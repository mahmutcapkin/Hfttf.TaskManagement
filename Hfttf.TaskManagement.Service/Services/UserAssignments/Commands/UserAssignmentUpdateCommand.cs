using Hfttf.TaskManagement.Core.Models;
using MediatR;
using System;

namespace Hfttf.TaskManagement.Service.Services.UserAssignments.Commands
{
    public class UserAssignmentUpdateCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public string UpdateBy { get; set; }
        public bool IsActive { get; set; }
        public string ApplicationUserId { get; set; }
        public int TaskId { get; set; }
    }
}
