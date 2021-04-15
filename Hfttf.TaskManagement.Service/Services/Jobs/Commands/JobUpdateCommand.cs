using Hfttf.TaskManagement.Core.Models;
using MediatR;
using System;

namespace Hfttf.TaskManagement.Service.Services.Jobs.Commands
{
    public class JobUpdateCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
