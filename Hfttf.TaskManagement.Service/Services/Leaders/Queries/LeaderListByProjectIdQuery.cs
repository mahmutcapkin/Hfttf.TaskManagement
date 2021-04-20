using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Leaders.Queries
{
    public class LeaderListByProjectIdQuery : IRequest<Response>
    {
        public int? ProjectId { get; set; }
    }
}
