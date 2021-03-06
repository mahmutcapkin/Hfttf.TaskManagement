using AutoMapper;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.ResourceViewModel;
using Hfttf.TaskManagement.Service.Services.Leaders.Commands;
using Hfttf.TaskManagement.Service.Services.Leaders.Responses;
using Hfttf.TaskManagement.Service.Services.Projects.Responses;
using Hfttf.TaskManagement.Service.Services.Users.Responses;

namespace Hfttf.TaskManagement.Service.Services.Leaders.Mappers
{
    public class LeaderProfile : Profile
    {
        public LeaderProfile()
        {
            CreateMap<LeaderInsertCommand, Leader>().ReverseMap();
            CreateMap<LeaderUpdateCommand, Leader>().ReverseMap();
            CreateMap<LeaderDeleteCommand, Leader>().ReverseMap();
            CreateMap<Leader, LeaderResponse>().ReverseMap();
            CreateMap<Leader, LeaderForUserResponse>().ReverseMap();
            CreateMap<Leader, LeaderForProjectResponse>().ReverseMap();
            CreateMap<ApplicationUser, UserViewResponse>().ReverseMap();
            CreateMap<Project, ProjectResponse>().ReverseMap();
        }
    }
}
