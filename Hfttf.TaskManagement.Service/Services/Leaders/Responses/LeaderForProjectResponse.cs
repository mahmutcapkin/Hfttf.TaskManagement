using Hfttf.TaskManagement.Core.ResourceViewModel;

namespace Hfttf.TaskManagement.Service.Services.Leaders.Responses
{
    public class LeaderForProjectResponse
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public int ProjectId { get; set; }
        public UserViewResponse ApplicationUser { get; set; }
    }
}
