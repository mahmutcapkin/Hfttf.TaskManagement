using AutoMapper;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.ResourceViewModel;
using Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Commands;
using Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Responses;
using Hfttf.TaskManagement.Service.Services.Users.Responses;

namespace Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Mappers
{
    public class EmergencyContactInfoProfile : Profile
    {
        public EmergencyContactInfoProfile()
        {
            CreateMap<EmergencyContactInfoDeleteCommand, EmergencyContactInfo>().ReverseMap();
            CreateMap<EmergencyContactInfoInsertCommand, EmergencyContactInfo>().ReverseMap();
            CreateMap<EmergencyContactInfoUpdateCommand, EmergencyContactInfo>().ReverseMap();
            CreateMap<EmergencyContactInfo, EmergencyContactInfoResponse>().ReverseMap();       
            CreateMap<EmergencyContactInfo, EmergencyContactUserInfoResponse>().ReverseMap();
            CreateMap<ApplicationUser, UserViewResponse>().ReverseMap();
        }
    }
}
