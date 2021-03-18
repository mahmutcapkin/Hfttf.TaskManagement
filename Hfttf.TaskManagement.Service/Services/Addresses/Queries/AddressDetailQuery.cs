using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Addresses.Queries
{
    public class AddressDetailQuery : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
