using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Commands
{
    public class EmergencyContactInfoUpdateCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RelationShip { get; set; }
        public string Phone { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
