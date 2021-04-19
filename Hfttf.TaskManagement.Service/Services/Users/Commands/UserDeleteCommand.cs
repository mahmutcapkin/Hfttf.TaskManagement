using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Users.Commands
{
    public class UserDeleteCommand : IRequest<Response>
    {
        public string Id { get; set; }
    }
}
