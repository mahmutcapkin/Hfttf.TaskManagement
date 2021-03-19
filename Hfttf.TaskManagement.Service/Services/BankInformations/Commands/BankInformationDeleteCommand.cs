using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.BankInformations.Commands
{
    public class BankInformationDeleteCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
