using AutoMapper;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Service.Services.BankInformations.Commands;
using Hfttf.TaskManagement.Service.Services.BankInformations.Responses;

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
        }
    }
}
