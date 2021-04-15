﻿using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Addresses.Commands;
using Hfttf.TaskManagement.Service.Services.Addresses.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Addresses.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Addresses.Handlers
{
    public class AddressUpdateHandler : BaseAddressHandler, IRequestHandler<AddressUpdateCommand, Response>
    {
        public AddressUpdateHandler(IAddressRepository addressRepository) : base(addressRepository)
        {
        }
        public async Task<Response> Handle(AddressUpdateCommand request, CancellationToken cancellationToken)
        {
            var address = TaskManagementMapper.Mapper.Map<Address>(request);
            var response = await _addressRepository.UpdateAsync(address);
            var addressResponse = TaskManagementMapper.Mapper.Map<AddressResponse>(response);
            var result = Response.Success(addressResponse, 200);
            return result;
        }
    }
}
