using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Leaders.Commands
{
    public class LeaderUpdateCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public int? ProjectId { get; set; }
    }
}
