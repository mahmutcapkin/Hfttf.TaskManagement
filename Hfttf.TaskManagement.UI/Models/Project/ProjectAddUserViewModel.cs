using Hfttf.TaskManagement.UI.Models.Leader;

namespace Hfttf.TaskManagement.UI.Models.Project
{
    public class ProjectAddUserViewModel
    {
        public ProjectResponse Project { get; set; }
        public ProjectAssignUser Assign { get; set; }

        public LeaderUpdate LeaderAssign { get; set; }
    }
}
