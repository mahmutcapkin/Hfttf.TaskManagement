using Hfttf.TaskManagement.Core.ResourceViewModel;
using Hfttf.TaskManagement.Service.Services.Projects.Responses;
using Hfttf.TaskManagement.Service.Services.Users.Responses;

namespace Hfttf.TaskManagement.Service.Services.Leaders.Responses
{
    public class LeaderResponse
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public int? ProjectId { get; set; }
        public UserViewResponse ApplicationUser { get; set; }
        public ProjectForLeaderResponse Project { get; set; }

    }
}
