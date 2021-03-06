using Hfttf.TaskManagement.Service.Services.Users.Responses;

namespace Hfttf.TaskManagement.Service.Services.BankInformations.Responses
{
    public class BankInformationResponse
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string IBANNo { get; set; }
        public string ApplicationUserId { get; set; }
        public UserViewResponse ApplicationUser { get; set; }
    }
}
