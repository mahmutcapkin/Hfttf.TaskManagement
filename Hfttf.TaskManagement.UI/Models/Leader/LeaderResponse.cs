using Hfttf.TaskManagement.UI.Models.Authentication;
using Hfttf.TaskManagement.UI.Models.Project;
using Hfttf.TaskManagement.UI.Models.User;

namespace Hfttf.TaskManagement.UI.Models.Leader
{
    public class LeaderResponse
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public int? ProjectId { get; set; }
        public UserResponse ApplicationUser { get; set; }
        public ProjectForLeaderResponse Project { get; set; }
    }
}
