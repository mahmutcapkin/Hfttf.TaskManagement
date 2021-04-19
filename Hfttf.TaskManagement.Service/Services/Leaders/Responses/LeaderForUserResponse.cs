using Hfttf.TaskManagement.Service.Services.Projects.Responses;

namespace Hfttf.TaskManagement.Service.Services.Leaders.Responses
{
    public class LeaderForUserResponse
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public int ProjectId { get; set; }
        public ProjectResponse Project { get; set; }
    }
}
