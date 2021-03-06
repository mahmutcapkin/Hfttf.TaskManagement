using AutoMapper;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.ResourceViewModel;
using Hfttf.TaskManagement.Service.Services.TaskStatuses.Commands;
using Hfttf.TaskManagement.Service.Services.TaskStatuses.Responses;
using Hfttf.TaskManagement.Service.Services.Users.Responses;

namespace Hfttf.TaskManagement.Service.Services.TaskStatuses.Mappers
{
    public class TaskStatusProfile : Profile
    {
        public TaskStatusProfile()
        {
            CreateMap<TaskStatusInsertCommand, TaskStatus>().ReverseMap();
            CreateMap<TaskStatusDeleteCommand, TaskStatus>().ReverseMap();
            CreateMap<TaskStatusUpdateCommand, TaskStatus>().ReverseMap();
            CreateMap<TaskStatus, TaskStatusResponse>().ReverseMap();
            CreateMap<TaskStatus, TaskStatusForTaskResponse>().ReverseMap();
            CreateMap<ApplicationUser, UserViewResponse>().ReverseMap();
        }
    }
}
