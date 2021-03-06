using Hfttf.TaskManagement.UI.Models.User;

namespace Hfttf.TaskManagement.UI.Models.Experience
{
    public class ExperienceResponse
    {
        public int Id { get; set; }
        public string Job { get; set; }
        public string Company { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ApplicationUserId { get; set; }
        public UserResponse ApplicationUser { get; set; }
    }
}
