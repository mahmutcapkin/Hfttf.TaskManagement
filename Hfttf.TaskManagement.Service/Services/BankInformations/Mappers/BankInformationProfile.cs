using AutoMapper;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.ResourceViewModel;
using Hfttf.TaskManagement.Service.Services.BankInformations.Commands;
using Hfttf.TaskManagement.Service.Services.BankInformations.Responses;
using Hfttf.TaskManagement.Service.Services.Users.Responses;

namespace Hfttf.TaskManagement.Service.Services.BankInformations.Mappers
{
    public class BankInformationProfile : Profile
    {
        public BankInformationProfile()
        {
            CreateMap<BankInformationDeleteCommand, BankInformation>().ReverseMap();
            CreateMap<BankInformationInsertCommand, BankInformation>().ReverseMap();
            CreateMap<BankInformationUpdateCommand, BankInformation>().ReverseMap();
            CreateMap<BankInformation, BankInformationResponse>().ReverseMap();
            CreateMap<BankInformation, BankInformationForUserInfoResponse>().ReverseMap();
            CreateMap<ApplicationUser, UserViewResponse>().ReverseMap();
        }
    }
}
