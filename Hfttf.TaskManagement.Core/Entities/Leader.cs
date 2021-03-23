using Hfttf.TaskManagement.Core.Entities.Base;

namespace Hfttf.TaskManagement.Core.Entities
{
    public class Leader : Entity
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int? ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
