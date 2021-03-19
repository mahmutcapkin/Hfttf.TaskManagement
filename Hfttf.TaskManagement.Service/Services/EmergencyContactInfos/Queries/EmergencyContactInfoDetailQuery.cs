using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Queries
{
    public class EmergencyContactInfoDetailQuery : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
