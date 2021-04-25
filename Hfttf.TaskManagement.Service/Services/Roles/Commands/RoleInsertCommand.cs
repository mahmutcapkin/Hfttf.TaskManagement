using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Roles.Commands
{
    public class RoleInsertCommand : IRequest<Response>
    {
        public string Name { get; set; }
    }
}
