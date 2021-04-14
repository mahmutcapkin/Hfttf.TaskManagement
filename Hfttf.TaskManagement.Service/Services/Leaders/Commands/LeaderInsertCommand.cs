using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Leaders.Commands
{
    public class LeaderInsertCommand : IRequest<Response>
    {
        public string ApplicationUserId { get; set; }
        public int? ProjectId { get; set; }
    }
}
