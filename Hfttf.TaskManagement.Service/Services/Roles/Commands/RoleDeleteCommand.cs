using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Roles.Commands
{
    public class RoleDeleteCommand : IRequest<Response>
    {
        public string Id { get; set; }
    }
}
