using AutoMapper;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Service.Services.Projects.Commands;
using Hfttf.TaskManagement.Service.Services.Projects.Responses;

namespace Hfttf.TaskManagement.Service.Services.Projects.Mappers
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<ProjectInsertCommand, Project>().ReverseMap();
            CreateMap<ProjectDeleteCommand, Project>().ReverseMap();
            CreateMap<ProjectUpdateCommand, Project>().ReverseMap();
            CreateMap<Project, ProjectResponse>().ReverseMap();
        }
    }
}

