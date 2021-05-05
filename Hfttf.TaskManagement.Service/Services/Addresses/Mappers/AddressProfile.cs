using AutoMapper;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.ResourceViewModel;
using Hfttf.TaskManagement.Service.Services.Addresses.Commands;
using Hfttf.TaskManagement.Service.Services.Addresses.Responses;
using Hfttf.TaskManagement.Service.Services.Users.Responses;

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
            CreateMap<ApplicationUser, UserViewResponse>().ReverseMap();
            CreateMap<Address, AddressForUserInfoResponse>().ReverseMap();
        }
    }
}
