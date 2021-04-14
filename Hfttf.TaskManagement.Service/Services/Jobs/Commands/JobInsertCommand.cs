using Hfttf.TaskManagement.Core.Models;
using MediatR;
using System;

namespace Hfttf.TaskManagement.Service.Services.Jobs.Commands
{
    public class JobInsertCommand : IRequest<Response>
    {
        public string Name { get; set; }
        public string CreateBy { get; set; }
        public bool IsActive { get; set; }
    }
}
