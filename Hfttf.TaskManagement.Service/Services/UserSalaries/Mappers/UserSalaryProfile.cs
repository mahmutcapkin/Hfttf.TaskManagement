using AutoMapper;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Service.Services.UserSalaries.Commands;
using Hfttf.TaskManagement.Service.Services.UserSalaries.Responses;

namespace Hfttf.TaskManagement.Service.Services.UserSalaries.Mappers
{
    public class UserSalaryProfile : Profile
    {
        public UserSalaryProfile()
        {
            CreateMap<UserSalaryInsertCommand, UserSalary>().ReverseMap();
            CreateMap<UserSalaryDeleteCommand, UserSalary>().ReverseMap();
            CreateMap<UserSalaryUpdateCommand, UserSalary>().ReverseMap();
            CreateMap<UserSalary, UserSalaryResponse>().ReverseMap();
        }
    }
}
