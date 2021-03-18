using FluentValidation;
using Hfttf.TaskManagement.Core.Models.Pagination;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Core.Repositories.Base;
using Hfttf.TaskManagement.Infrastructure.Data.EntityFrameworkCore;
using Hfttf.TaskManagement.Infrastructure.Repositories.Base;
using Hfttf.TaskManagement.Infrastructure.Repositories.EntityFrameworkCoreRepositories;
using Hfttf.TaskManagement.Service.PipelineBehaviours;
using Hfttf.TaskManagement.Service.Services.Addresses.Handlers;
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

            #endregion
        }

        public static void AddCustomMediatR(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(IMediator).Assembly);

            //#region Task Handlers
            //services.AddMediatR(typeof(TaskInsertHandler).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(TaskDetailHandler).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(TaskUpdateHandler).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(TaskListHandler).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(TaskListPaginationHandler).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(TaskListByProjectIdHandler).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(TaskListByProjectIdPaginationHandler).GetTypeInfo().Assembly);
            //#endregion
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

        }
    }
}
