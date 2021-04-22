using AutoMapper;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.ResourceViewModel;
using Hfttf.TaskManagement.Service.Services.Jobs.Commands;
using Hfttf.TaskManagement.Service.Services.Jobs.Responses;

namespace Hfttf.TaskManagement.Service.Services.Jobs.Mappers
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<JobInsertCommand, Job>().ReverseMap();
            CreateMap<JobUpdateCommand, Job>().ReverseMap();
            CreateMap<JobDeleteCommand, Job>().ReverseMap();
            CreateMap<Job, JobResponse>().ReverseMap();
            CreateMap<Job, JobForUserResponse>().ReverseMap();
            CreateMap<ApplicationUser, UserViewResponse>().ReverseMap();
        }
    }
}
