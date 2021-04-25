using Hfttf.TaskManagement.Core.Models;
using MediatR;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Service.Services.Roles.Commands
{
    public class RoleAssignRoleToUserCommand : IRequest<Response>
    {
        public string UserId { get; set; }
        public List<string> RoleId { get; set; }
    }
}
