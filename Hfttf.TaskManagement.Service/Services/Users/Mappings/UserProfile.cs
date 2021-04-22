using AutoMapper;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.ResourceViewModel;
using Hfttf.TaskManagement.Service.Services.Users.Commands;
using Hfttf.TaskManagement.Service.Services.Users.Responses;

namespace Hfttf.TaskManagement.Service.Services.Users.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserInsertCommand, ApplicationUser>().ReverseMap();
            CreateMap<UserDeleteCommand, ApplicationUser>().ReverseMap();
            CreateMap<UserUpdateCommand, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUser, UserResponse>().ReverseMap();
            CreateMap<ApplicationUser, UserViewResponse>().ReverseMap();
        }

    }
}
