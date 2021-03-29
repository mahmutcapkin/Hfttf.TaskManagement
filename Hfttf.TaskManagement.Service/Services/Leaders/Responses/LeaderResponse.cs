using Hfttf.TaskManagement.Core.ResourceViewModel;
using Hfttf.TaskManagement.Service.Services.Projects.Responses;

namespace Hfttf.TaskManagement.Service.Services.Leaders.Responses
{
    public class LeaderResponse
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ProjectId { get; set; }
        public UserViewResponse ApplicationUser { get; set; }
        public ProjectResponse Project { get; set; }

    }
}
