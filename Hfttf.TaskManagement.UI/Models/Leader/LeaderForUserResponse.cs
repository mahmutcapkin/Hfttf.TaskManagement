using Hfttf.TaskManagement.UI.Models.Project;

namespace Hfttf.TaskManagement.UI.Models.Leader
{
    public class LeaderForUserResponse
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public int ProjectId { get; set; }
        public ProjectResponse Project { get; set; }
    }
}
