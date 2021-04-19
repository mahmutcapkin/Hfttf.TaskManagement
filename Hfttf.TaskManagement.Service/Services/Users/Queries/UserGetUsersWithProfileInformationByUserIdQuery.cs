using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Users.Queries
{
    public class UserGetUsersWithProfileInformationByUserIdQuery : IRequest<Response>
    {
        public string UserId { get; set; }
    }
}
