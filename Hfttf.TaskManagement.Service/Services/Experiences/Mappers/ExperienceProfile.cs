using AutoMapper;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.ResourceViewModel;
using Hfttf.TaskManagement.Service.Services.Experiences.Commands;
using Hfttf.TaskManagement.Service.Services.Experiences.Responses;
using Hfttf.TaskManagement.Service.Services.Users.Responses;

namespace Hfttf.TaskManagement.Service.Services.Experiences.Mappers
{
    public class ExperienceProfile : Profile
    {
        public ExperienceProfile()
        {
            CreateMap<ExperienceDeleteCommand, Experience>().ReverseMap();
            CreateMap<ExperienceInsertCommand, Experience>().ReverseMap();
            CreateMap<ExperienceUpdateCommand, Experience>().ReverseMap();
            CreateMap<Experience, ExperienceResponse>().ReverseMap();
            CreateMap<Experience, ExperienceForUserInfoResponse>().ReverseMap();
            CreateMap<ApplicationUser, UserViewResponse>().ReverseMap();
        }
    }
}
