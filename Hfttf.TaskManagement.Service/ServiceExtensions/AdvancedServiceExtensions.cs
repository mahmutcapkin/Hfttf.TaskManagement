using FluentValidation;
using Hfttf.TaskManagement.Core.MinIOInterface;
using Hfttf.TaskManagement.Core.Models.Pagination;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Core.Repositories.Base;
using Hfttf.TaskManagement.Infrastructure.Data.EntityFrameworkCore;
using Hfttf.TaskManagement.Infrastructure.MinIO;
using Hfttf.TaskManagement.Infrastructure.Repositories.Base;
using Hfttf.TaskManagement.Infrastructure.Repositories.EntityFrameworkCoreRepositories;
using Hfttf.TaskManagement.Service.PipelineBehaviours;
using Hfttf.TaskManagement.Service.Services.Addresses.Handlers;
using Hfttf.TaskManagement.Service.Services.BankInformations.Handlers;
using Hfttf.TaskManagement.Service.Services.Departments.Handlers;
using Hfttf.TaskManagement.Service.Services.EducationInformations.Handlers;
using Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Handlers;
using Hfttf.TaskManagement.Service.Services.Experiences.Handlers;
using Hfttf.TaskManagement.Service.Services.Holidays.Handlers;
using Hfttf.TaskManagement.Service.Services.Leaders.Handlers;
using Hfttf.TaskManagement.Service.Services.Projects.Handlers;
using Hfttf.TaskManagement.Service.Services.Tasks.Handlers;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Handlers;
using Hfttf.TaskManagement.Service.Services.UserSalaries.Handlers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Hfttf.TaskManagement.Service.ServiceExtensions
{
    public static class AdvancedServiceExtensions
    {
        public static void AddCustomDbContext(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<TaskManagementContext>(c => c.UseSqlServer(connectionString));
        }

        public static void AddContainerWithDependencies(this IServiceCollection services)
        {
            #region HttpContextAccessor
            services.AddHttpContextAccessor();
            services.AddSingleton<IUriService>(o =>
            {
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(uri);
            });
            #endregion

            #region Core Layer Dependencies

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IAddressRepository), typeof(AddressRepositoryEf));
            services.AddScoped(typeof(IDepartmentRepository), typeof(DepartmentRepositoryEf));
            services.AddScoped(typeof(IHolidayRepository), typeof(HolidayRepositoryEf));
            services.AddScoped(typeof(IProjectRepository), typeof(ProjectRepositoryEf));
            services.AddScoped(typeof(IUserAssignmentRepository), typeof(UserAssignmentRepositoryEf));
            services.AddScoped(typeof(ITaskRepository), typeof(TaskRepositoryEf));
            services.AddScoped(typeof(IUserSalaryRepository), typeof(UserSalaryRepositoryEf));
            services.AddScoped(typeof(ITaskStatusRepository), typeof(TaskStatusRepositoryEf));
            services.AddScoped(typeof(IJobRepository), typeof(JobRepositoryEf));
            services.AddScoped(typeof(ICreateMinioClient), typeof(CreateMinioClient));

            services.AddScoped(typeof(IEmergencyContactInfoRepository), typeof(EmergencyContactInfoRepositoryEf));
            services.AddScoped(typeof(IBankInformationRepository), typeof(BankInformationRepositoryEf));
            services.AddScoped(typeof(IEducationInformationRepository), typeof(EducationInformationRepositoryEf));
            services.AddScoped(typeof(IExperienceRepository), typeof(ExperienceRepositoryEf));
            services.AddScoped(typeof(ILeaderRepository), typeof(LeaderRepositoryEf));

            #endregion
        }

        public static void AddCustomMediatR(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(IMediator).Assembly);

            #region Task Handlers
            services.AddMediatR(typeof(TaskInsertHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(TaskDetailHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(TaskUpdateHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(TaskListHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(TaskListPaginationHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(TaskListByProjectIdHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(TaskListByProjectIdPaginationHandler).GetTypeInfo().Assembly);
            #endregion
        }

        public static void AddDomainLevelValidation(this IServiceCollection services)
        {

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            // CTRL + K + S    for regions

            #region Address Validators
            AssemblyScanner.FindValidatorsInAssembly(typeof(AddressInsertHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            AssemblyScanner.FindValidatorsInAssembly(typeof(AddressUpdateHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            AssemblyScanner.FindValidatorsInAssembly(typeof(AddressDeleteHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            AssemblyScanner.FindValidatorsInAssembly(typeof(AddressDetailHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));

            #endregion

            #region UserAssignment Validators
            AssemblyScanner.FindValidatorsInAssembly(typeof(UserAssignmentInsertHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            AssemblyScanner.FindValidatorsInAssembly(typeof(UserAssignmentUpdateHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            AssemblyScanner.FindValidatorsInAssembly(typeof(UserAssignmentDeleteHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            AssemblyScanner.FindValidatorsInAssembly(typeof(UserAssignmentDetailHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            #endregion

            #region Task Validators
            AssemblyScanner.FindValidatorsInAssembly(typeof(TaskInsertHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            AssemblyScanner.FindValidatorsInAssembly(typeof(TaskDetailHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            AssemblyScanner.FindValidatorsInAssembly(typeof(TaskUpdateHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            AssemblyScanner.FindValidatorsInAssembly(typeof(TaskDeleteHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            #endregion

            #region Department Validators
            AssemblyScanner.FindValidatorsInAssembly(typeof(DepartmentInsertHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            AssemblyScanner.FindValidatorsInAssembly(typeof(DepartmentUpdateHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            AssemblyScanner.FindValidatorsInAssembly(typeof(DepartmentDeleteHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            AssemblyScanner.FindValidatorsInAssembly(typeof(DepartmentDetailHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));

            #endregion


            #region Holiday Validators
            AssemblyScanner.FindValidatorsInAssembly(typeof(HolidayInsertHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            AssemblyScanner.FindValidatorsInAssembly(typeof(HolidayUpdateHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            AssemblyScanner.FindValidatorsInAssembly(typeof(HolidayDeleteHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            AssemblyScanner.FindValidatorsInAssembly(typeof(HolidayDetailHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));

            #endregion

            #region Project Validators
            AssemblyScanner.FindValidatorsInAssembly(typeof(ProjectInsertHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            AssemblyScanner.FindValidatorsInAssembly(typeof(ProjectUpdateHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            AssemblyScanner.FindValidatorsInAssembly(typeof(ProjectDeleteHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            AssemblyScanner.FindValidatorsInAssembly(typeof(ProjectDetailHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));

            #endregion


            #region UserSalary Validators
            AssemblyScanner.FindValidatorsInAssembly(typeof(UserSalaryInsertHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            AssemblyScanner.FindValidatorsInAssembly(typeof(UserSalaryUpdateHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            AssemblyScanner.FindValidatorsInAssembly(typeof(UserSalaryDeleteHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            AssemblyScanner.FindValidatorsInAssembly(typeof(UserSalaryDetailHandler).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));

            #endregion

            #region EmergencyContactInfo Handlers
            services.AddMediatR(typeof(EmergencyContactInfoInsertHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(EmergencyContactInfoDeleteHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(EmergencyContactInfoUpdateHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(EmergencyContactInfoListHandler).GetTypeInfo().Assembly);
            #endregion

            #region BankInformation Handlers
            services.AddMediatR(typeof(BankInformationInsertHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(BankInformationDeleteHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(BankInformationUpdateHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(BankInformationListHandler).GetTypeInfo().Assembly);
            #endregion

            #region EducationInformation Handlers
            services.AddMediatR(typeof(EducationInformationInsertHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(EducationInformationDeleteHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(EducationInformationUpdateHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(EducationInformationListHandler).GetTypeInfo().Assembly);
            #endregion

            #region Experience Handlers
            services.AddMediatR(typeof(ExperienceInsertHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ExperienceDeleteHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ExperienceUpdateHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ExperienceListHandler).GetTypeInfo().Assembly);
            #endregion

            #region Leader Handlers
            services.AddMediatR(typeof(LeaderInsertHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(LeaderDeleteHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(LeaderUpdateHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(LeaderListHandler).GetTypeInfo().Assembly);
            #endregion

        }
    }
}
