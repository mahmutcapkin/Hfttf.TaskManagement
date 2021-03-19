using Hfttf.TaskManagement.Core.Entities;

namespace Hfttf.TaskManagement.Service.Services.BankInformations.Responses
{
    public class BankInformationResponse
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string IFSCNo { get; set; }
        public string ApplicationUserId { get; set; }
        //public ApplicationUser ApplicationUser { get; set; }
    }
}
