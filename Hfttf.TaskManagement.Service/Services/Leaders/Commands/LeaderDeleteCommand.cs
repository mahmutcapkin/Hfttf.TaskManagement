using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Leaders.Commands
{
    public class LeaderDeleteCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
