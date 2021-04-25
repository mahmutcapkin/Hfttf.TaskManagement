using AutoMapper;
using Hfttf.TaskManagement.Service.Services.Addresses.Mappers;
using Hfttf.TaskManagement.Service.Services.BankInformations.Mappers;
using Hfttf.TaskManagement.Service.Services.Departments.Mappers;
using Hfttf.TaskManagement.Service.Services.EducationInformations.Mappers;
using Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Mappers;
using Hfttf.TaskManagement.Service.Services.Experiences.Mappers;
using Hfttf.TaskManagement.Service.Services.Jobs.Mappers;
using Hfttf.TaskManagement.Service.Services.Leaders.Mappers;
using Hfttf.TaskManagement.Service.Services.Leaves.Mappers;
using Hfttf.TaskManagement.Service.Services.Projects.Mappers;
using Hfttf.TaskManagement.Service.Services.Roles.Mappers;
using Hfttf.TaskManagement.Service.Services.Tasks.Mappers;
using Hfttf.TaskManagement.Service.Services.TaskStatuses.Mappers;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Mappers;
using Hfttf.TaskManagement.Service.Services.Users.Mappings;
using Hfttf.TaskManagement.Service.Services.UserSalaries.Mappers;
using System;

namespace Hfttf.TaskManagement.Service.Mappers
{
    public class TaskManagementMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(configuration =>
            {
                // This line ensures that internal properties are also mapped over.
                configuration.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                configuration.AddProfile<AddressProfile>();
                configuration.AddProfile<TaskProfile>();
                configuration.AddProfile<UserAssignmentProfile>();
                configuration.AddProfile<ProjectProfile>();
                configuration.AddProfile<LeaveProfile>();
                configuration.AddProfile<UserSalaryProfile>();
                configuration.AddProfile<DepartmentProfile>();
                configuration.AddProfile<TaskStatusProfile>();
                configuration.AddProfile<JobProfile>();
                configuration.AddProfile<DepartmentProfile>();

                configuration.AddProfile<EmergencyContactInfoProfile>();
                configuration.AddProfile<BankInformationProfile>();
                configuration.AddProfile<EducationInformationProfile>();
                configuration.AddProfile<ExperienceProfile>();
                configuration.AddProfile<LeaderProfile>();
                configuration.AddProfile<UserProfile>();
                configuration.AddProfile<RoleProfile>();

            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }
}
