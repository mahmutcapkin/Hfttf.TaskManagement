using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.BankInformations.Queries
{
    public class BankInformationDetailQuery : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
