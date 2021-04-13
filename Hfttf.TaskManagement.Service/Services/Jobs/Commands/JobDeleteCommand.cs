using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Jobs.Commands
{
    public class JobDeleteCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
