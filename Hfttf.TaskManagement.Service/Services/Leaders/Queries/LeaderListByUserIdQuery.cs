using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Leaders.Queries
{
    public class LeaderListByUserIdQuery : IRequest<Response>
    {
        public string UserId { get; set; }
    }
}
