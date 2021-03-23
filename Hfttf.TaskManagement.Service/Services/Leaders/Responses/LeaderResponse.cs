using Hfttf.TaskManagement.Service.Services.Projects.Responses;
using Hfttf.TaskManagement.Service.Services.Users.Responses;

namespace Hfttf.TaskManagement.Service.Services.Leaders.Responses
{
    public class LeaderResponse
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ProjectId { get; set; }
        public UserResponse User { get; set; }
        public ProjectResponse Project { get; set; }

    }
}
