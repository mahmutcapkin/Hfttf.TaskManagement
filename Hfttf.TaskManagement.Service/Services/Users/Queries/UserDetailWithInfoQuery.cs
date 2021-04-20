using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Users.Queries
{
    public class UserDetailWithInfoQuery : IRequest<Response>
    {
        public string Id { get; set; }

    }
}
