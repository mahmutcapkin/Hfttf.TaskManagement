using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Addresses.Commands
{
    public class AddressDeleteCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
