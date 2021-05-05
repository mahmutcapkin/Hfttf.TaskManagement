using Hfttf.TaskManagement.Core.ResourceViewModel;
using Hfttf.TaskManagement.Service.Services.Users.Responses;

namespace Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Responses
{
    public class EmergencyContactInfoResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RelationShip { get; set; }
        public string Phone { get; set; }
        public string ApplicationUserId { get; set; }
        public UserViewResponse ApplicationUser { get; set; }
    }
}
