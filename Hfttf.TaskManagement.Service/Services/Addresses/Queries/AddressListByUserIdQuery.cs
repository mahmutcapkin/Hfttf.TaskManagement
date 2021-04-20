using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Addresses.Queries
{
    public class AddressListByUserIdQuery : IRequest<Response>
    {
        public string UserId { get; set; }
    }
}
