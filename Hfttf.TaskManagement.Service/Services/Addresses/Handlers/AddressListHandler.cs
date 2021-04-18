using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Addresses.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Addresses.Queries;
using Hfttf.TaskManagement.Service.Services.Addresses.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Addresses.Handlers
{
    public class AddressListHandler : BaseAddressHandler, IRequestHandler<AddressListQuery, Response>
    {
        public AddressListHandler(IAddressRepository addressRepository) : base(addressRepository)
        {
        }
        public async Task<Response> Handle(AddressListQuery request, CancellationToken cancellationToken)
        {
            var addresses = await _addressRepository.GetListWithUser();
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<AddressResponse>>(addresses);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
