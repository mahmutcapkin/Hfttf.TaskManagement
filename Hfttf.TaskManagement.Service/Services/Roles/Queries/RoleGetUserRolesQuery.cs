using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Roles.Queries
{
    public class RoleGetUserRolesQuery : IRequest<Response>
    {
        public string Id { get; set; }
    }
}
