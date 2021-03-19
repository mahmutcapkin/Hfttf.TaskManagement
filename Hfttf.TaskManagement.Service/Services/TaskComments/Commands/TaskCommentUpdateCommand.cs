using Hfttf.TaskManagement.Core.Models;
using MediatR;
using System;

namespace Hfttf.TaskManagement.Service.Services.TaskComments.Commands
{
    public class TaskCommentUpdateCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string UpdateBy { get; set; }
        public bool IsActive { get; set; }
        public int TaskId { get; set; }
    }
}
