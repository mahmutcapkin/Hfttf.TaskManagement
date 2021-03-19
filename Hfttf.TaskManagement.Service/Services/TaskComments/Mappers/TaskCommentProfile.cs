using AutoMapper;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Service.Services.TaskComments.Commands;
using Hfttf.TaskManagement.Service.Services.TaskComments.Responses;

namespace Hfttf.TaskManagement.Service.Services.TaskComments.Mappers
{
    public class TaskCommentProfile : Profile
    {
        public TaskCommentProfile()
        {
            CreateMap<TaskCommentInsertCommand, TaskComment>().ReverseMap();
            CreateMap<TaskCommentUpdateCommand, TaskComment>().ReverseMap();
            CreateMap<TaskCommentDeleteCommand, TaskComment>().ReverseMap();
            CreateMap<TaskComment, TaskCommentResponse>().ReverseMap();
        }
    }
}
