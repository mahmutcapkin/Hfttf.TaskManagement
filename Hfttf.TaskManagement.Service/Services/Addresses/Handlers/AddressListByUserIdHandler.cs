using Hfttf.TaskManagement.Core.Entities;
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
    public class AddressListByUserIdHandler : BaseAddressHandler, IRequestHandler<AddressListByUserIdQuery, Response>
    {
        public AddressListByUserIdHandler(IAddressRepository addressRepository) : base(addressRepository)
        {
        }
        public async Task<Response> Handle(AddressListByUserIdQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Address> address;
            if (request.UserId == null)
            {
                address = await _addressRepository.GetListWithUser();
            }
            else
            {
                address = await _addressRepository.GetListWithUserByUserId(request.UserId);
            } 
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<AddressResponse>>(address);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
