using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Users.Commands
{
    public class UserUpdateForJobCommand : IRequest<Response>
    {
        public string UserId { get; set; }
        public int? JobId { get; set; }
    }
}
