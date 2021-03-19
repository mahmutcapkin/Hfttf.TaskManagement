using Hfttf.TaskManagement.Core.Entities.Base;

namespace Hfttf.TaskManagement.Core.Entities
{
    public class EmergencyContactInfo : Entity
    {
        public string Name { get; set; }
        public string RelationShip { get; set; }
        public string Phone { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
