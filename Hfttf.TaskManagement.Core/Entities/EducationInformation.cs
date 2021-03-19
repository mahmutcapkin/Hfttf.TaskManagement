using Hfttf.TaskManagement.Core.Entities.Base;

namespace Hfttf.TaskManagement.Core.Entities
{
    public class EducationInformation : Entity
    {
        public string SchoolName { get; set; }
        public string Section { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
