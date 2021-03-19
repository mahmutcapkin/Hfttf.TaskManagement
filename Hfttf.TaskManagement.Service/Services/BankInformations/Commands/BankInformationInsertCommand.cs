using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.BankInformations.Commands
{
    public class BankInformationInsertCommand : IRequest<Response>
    {
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string IFSCNo { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
