using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Roles.Commands
{
    public class RoleUpdateCommand : IRequest<Response>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
