using AutoMapper;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.ResourceViewModel;
using Hfttf.TaskManagement.Service.Services.Leaves.Commands;
using Hfttf.TaskManagement.Service.Services.Leaves.Responses;

namespace Hfttf.TaskManagement.Service.Services.Leaves.Mappers
{
    public class LeaveProfile : Profile
    {
        public LeaveProfile()
        {
            CreateMap<LeaveDeleteCommand, Leave>().ReverseMap();
            CreateMap<LeaveInsertCommand, Leave>().ReverseMap();
            CreateMap<LeaveUpdateCommand, Leave>().ReverseMap();
            CreateMap<Leave, LeaveResponse>().ReverseMap();
            CreateMap<Leave, LeaveForUserResponse>().ReverseMap();
            CreateMap<ApplicationUser, UserViewResponse>().ReverseMap();
        }
    }
}
