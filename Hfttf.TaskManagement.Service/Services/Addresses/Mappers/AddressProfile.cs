using AutoMapper;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Service.Services.Addresses.Commands;
using Hfttf.TaskManagement.Service.Services.Addresses.Responses;

namespace Hfttf.TaskManagement.Service.Services.Addresses.Mappers
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressInsertCommand, Address>().ReverseMap();
            CreateMap<AddressUpdateCommand, Address>().ReverseMap();
            CreateMap<AddressDeleteCommand, Address>().ReverseMap();
            CreateMap<Address, AddressResponse>().ReverseMap();
        }
    }
}
