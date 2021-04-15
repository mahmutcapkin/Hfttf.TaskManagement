using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Jobs.Commands
{
    public class JobInsertCommand : IRequest<Response>
    {
        public string Name { get; set; }
    }
}
