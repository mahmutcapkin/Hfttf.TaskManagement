using AutoMapper;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Service.Services.Roles.Commands;
using Hfttf.TaskManagement.Service.Services.Roles.Responses;

namespace Hfttf.TaskManagement.Service.Services.Roles.Mappers
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleDeleteCommand, ApplicationRole>().ReverseMap();
            CreateMap<RoleInsertCommand, ApplicationRole>().ReverseMap();
            CreateMap<RoleUpdateCommand, ApplicationRole>().ReverseMap();
            CreateMap<ApplicationRole, RoleResponse>().ReverseMap();                   

        }
    }
}
