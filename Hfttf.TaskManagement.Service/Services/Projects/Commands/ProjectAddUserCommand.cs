using Hfttf.TaskManagement.Core.Models;
using MediatR;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Service.Services.Projects.Commands
{
    public class ProjectAddUserCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public IList<string> UserIds { get; set; }

    }
}
