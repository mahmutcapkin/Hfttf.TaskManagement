using AutoMapper;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Commands;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Responses;

namespace Hfttf.TaskManagement.Service.Services.UserAssignments.Mappers
{
    public class UserAssignmentProfile : Profile
    { 
        public UserAssignmentProfile()
        {
            CreateMap<UserAssignmentInsertCommand, UserAssignment>().ReverseMap();
            CreateMap<UserAssignmentUpdateCommand, UserAssignment>().ReverseMap();
            CreateMap<UserAssignmentDeleteCommand, UserAssignment>().ReverseMap();
            CreateMap<UserAssignment, UserAssignmentResponse>().ReverseMap();
        }
    }
}
