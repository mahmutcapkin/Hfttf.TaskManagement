using Hfttf.TaskManagement.Core.Entities.Base;

namespace Hfttf.TaskManagement.Core.Entities
{
    public class BankInformation : Entity
    {
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string IFSCNo { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
