using Hfttf.TaskManagement.Core.ResourceViewModel;
using Hfttf.TaskManagement.Service.Services.Users.Responses;

namespace Hfttf.TaskManagement.Service.Services.EducationInformations.Responses
{
    public class EducationInformationResponse
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string Section { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ApplicationUserId { get; set; }
        public UserViewResponse ApplicationUser { get; set; }
    }
}
