using Hfttf.TaskManagement.Core.Entities;

namespace Hfttf.TaskManagement.Service.Services.Experiences.Responses
{
    public class ExperienceResponse
    {
        public int Id { get; set; }
        public string Job { get; set; }
        public string Company { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ApplicationUserId { get; set; }
        //public ApplicationUser ApplicationUser { get; set; }
    }
}
