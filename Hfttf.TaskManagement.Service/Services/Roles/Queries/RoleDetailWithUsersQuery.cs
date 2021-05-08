using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Roles.Queries
{
    public class RoleDetailWithUsersQuery : IRequest<Response>
    {
        public string Id { get; set; }
    }
}
