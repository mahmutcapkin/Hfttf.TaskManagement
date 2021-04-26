using Hfttf.TaskManagement.UI.Models.Authentication;
using Hfttf.TaskManagement.UI.Models.User;

namespace Hfttf.TaskManagement.UI.Models.BankInformation
{
    public class BankInformationResponse
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string IBANNo { get; set; }
        public string ApplicationUserId { get; set; }
        public UserResponse ApplicationUser { get; set; }
    }
}
