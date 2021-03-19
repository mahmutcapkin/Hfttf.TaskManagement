using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Projects.Commands
{
    public class ProjectDeleteCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
