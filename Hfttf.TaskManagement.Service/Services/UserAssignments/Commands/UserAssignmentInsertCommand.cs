using Hfttf.TaskManagement.Core.Models;
using MediatR;
using System;

namespace Hfttf.TaskManagement.Service.Services.UserAssignments.Commands
{
    public class UserAssignmentInsertCommand : IRequest<Response>
    {
        public string CreateBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public string ApplicationUserId { get; set; }
        public int TaskId { get; set; }
    }
}
