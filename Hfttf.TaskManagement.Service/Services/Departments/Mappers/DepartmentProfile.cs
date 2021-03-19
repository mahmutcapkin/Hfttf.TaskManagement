using AutoMapper;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Service.Services.Departments.Commands;
using Hfttf.TaskManagement.Service.Services.Departments.Responses;

namespace Hfttf.TaskManagement.Service.Services.Departments.Mappers
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentInsertCommand, Department>().ReverseMap();
            CreateMap<DepartmentUpdateCommand, Department>().ReverseMap();
            CreateMap<DepartmentDeleteCommand, Department>().ReverseMap();
            CreateMap<Department, DepartmentResponse>().ReverseMap();
        }
    }
}
