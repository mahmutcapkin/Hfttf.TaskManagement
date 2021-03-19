using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Queries
{
    public class EmergencyContactInfoListByUserIdQuery : IRequest<Response>
    {
        public string UserId { get; set; }
    }
}
