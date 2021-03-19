using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.BankInformations.Queries
{
    public class BankInformationListByUserIdQuery : IRequest<Response>
    {
        public string UserId { get; set; }
    }
}
