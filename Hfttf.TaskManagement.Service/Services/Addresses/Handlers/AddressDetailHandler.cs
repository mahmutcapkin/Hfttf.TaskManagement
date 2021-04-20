using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Addresses.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Addresses.Queries;
using Hfttf.TaskManagement.Service.Services.Addresses.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Addresses.Handlers
{
    public class AddressDetailHandler : BaseAddressHandler, IRequestHandler<AddressDetailQuery, Response>
    {
        public AddressDetailHandler(IAddressRepository addressRepository) : base(addressRepository)
        {
        }
        public async Task<Response> Handle(AddressDetailQuery request, CancellationToken cancellationToken)
        {
            var attendance = await _addressRepository.GetAddressWithUserById(request.Id);
            var response = TaskManagementMapper.Mapper.Map<AddressResponse>(attendance);
            var result = Response.Success(response, 200);
            return result;
        }

    }
}
