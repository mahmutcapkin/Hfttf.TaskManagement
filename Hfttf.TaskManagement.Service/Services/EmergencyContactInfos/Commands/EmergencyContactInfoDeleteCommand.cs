using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Commands
{
    public class EmergencyContactInfoDeleteCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
