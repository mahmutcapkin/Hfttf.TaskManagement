using Hfttf.TaskManagement.UI.Models.Authentication;
using Hfttf.TaskManagement.UI.Models.User;

namespace Hfttf.TaskManagement.UI.Models.EducationInformation
{
    public class EducationInformationResponse
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string Section { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ApplicationUserId { get; set; }
        public UserResponse ApplicationUser { get; set; }
    }
}
