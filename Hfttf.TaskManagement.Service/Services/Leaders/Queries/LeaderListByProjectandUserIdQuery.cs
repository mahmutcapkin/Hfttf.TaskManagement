using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Leaders.Queries
{
    public class LeaderListByProjectandUserIdQuery : IRequest<Response>
    {
        public int? ProjectId { get; set; }
        public string UserId { get; set; }
    }
}
