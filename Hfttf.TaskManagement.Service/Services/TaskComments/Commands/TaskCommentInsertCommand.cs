using Hfttf.TaskManagement.Core.Models;
using MediatR;
using System;

namespace Hfttf.TaskManagement.Service.Services.TaskComments.Commands
{
    public class TaskCommentInsertCommand : IRequest<Response>
    {
        public string Comment { get; set; }
        public string CreateBy { get; set; }
        public bool IsActive { get; set; }
        public int TaskId { get; set; }
    }
}
