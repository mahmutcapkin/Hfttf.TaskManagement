using AutoMapper;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.ResourceViewModel;
using Hfttf.TaskManagement.Service.Services.EducationInformations.Commands;
using Hfttf.TaskManagement.Service.Services.EducationInformations.Responses;

namespace Hfttf.TaskManagement.Service.Services.EducationInformations.Mappers
{
    public class EducationInformationProfile : Profile
    {
        public EducationInformationProfile()
        {
            CreateMap<EducationInformationDeleteCommand, EducationInformation>().ReverseMap();
            CreateMap<EducationInformationInsertCommand, EducationInformation>().ReverseMap();
            CreateMap<EducationInformationUpdateCommand, EducationInformation>().ReverseMap();
            CreateMap<EducationInformation, EducationInformationResponse>().ReverseMap();
            CreateMap<EducationInformation, EducationInformationForUserInfoResponse>().ReverseMap();
            CreateMap<ApplicationUser, UserViewResponse>().ReverseMap();

        }
    }
}
