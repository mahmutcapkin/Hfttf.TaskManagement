using Hfttf.TaskManagement.UI.Models.User;

namespace Hfttf.TaskManagement.UI.Models.Leader
{
    public class LeaderForProjectResponse
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public int ProjectId { get; set; }
        public UserResponse ApplicationUser { get; set; }
    }
}
