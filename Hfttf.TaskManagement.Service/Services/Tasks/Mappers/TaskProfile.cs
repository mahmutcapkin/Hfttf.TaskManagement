using AutoMapper;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.ResourceViewModel;
using Hfttf.TaskManagement.Service.Services.Tasks.Commands;
using Hfttf.TaskManagement.Service.Services.Tasks.Responses;

namespace Hfttf.TaskManagement.Service.Services.Tasks.Mappers
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskInsertCommand, Task>().ReverseMap();
            CreateMap<TaskUpdateCommand, Task>().ReverseMap();
            CreateMap<TaskDeleteCommand, Task>().ReverseMap();
            CreateMap<Task, TaskResponse>().ReverseMap();
            CreateMap<Task, TaskForTaskStatusResponse>().ReverseMap();
            CreateMap<Task, TaskForProjectResponse>().ReverseMap();
            CreateMap<Task, TaskForUserAssignmentResponse>().ReverseMap();
            CreateMap<ApplicationUser, UserViewResponse>().ReverseMap();
        }
    }
}
