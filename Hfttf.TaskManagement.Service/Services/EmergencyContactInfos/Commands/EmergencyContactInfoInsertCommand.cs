using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Commands
{
    public class EmergencyContactInfoInsertCommand : IRequest<Response>
    {
        public string Name { get; set; }
        public string RelationShip { get; set; }
        public string Phone { get; set; }
        public string ApplicationUserId { get; set; }   
    }
}
