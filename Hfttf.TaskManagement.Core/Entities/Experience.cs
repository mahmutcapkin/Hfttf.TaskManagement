using Hfttf.TaskManagement.Core.Entities.Base;

namespace Hfttf.TaskManagement.Core.Entities
{
    public class Experience : Entity
    {
        public string Job { get; set; }
        public string Company { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
