using FluentValidation;
using FluentValidation.AspNetCore;
using Hfttf.TaskManagement.UI.ApiServices.Concrete;
using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models.Address;
using Hfttf.TaskManagement.UI.Models.Address.Validators;
using Hfttf.TaskManagement.UI.Models.BankInformation;
using Hfttf.TaskManagement.UI.Models.BankInformation.Validators;
using Hfttf.TaskManagement.UI.Models.Department;
using Hfttf.TaskManagement.UI.Models.Department.Validators;
using Hfttf.TaskManagement.UI.Models.EducationInformation;
using Hfttf.TaskManagement.UI.Models.EducationInformation.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI
{
    public class Startup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //#region Fluent Validation 
            //services.AddSingleton<IValidator<AddressAdd>, AddressAddValidator>();
            //services.AddSingleton<IValidator<AddressUpdate>, AddressUpdateValidator>();

            //services.AddTransient<IValidator<BankInformationAdd>, BankInformationAddValidator>();
            //services.AddTransient<IValidator<BankInformationUpdate>, BankInformationUpdateValidator>();

            //services.AddTransient<IValidator<DepartmentAdd>, DepartmentAddValidator>();
            //services.AddTransient<IValidator<DepartmentUpdate>, DepartmentUpdateValidator>();

            //services.AddTransient<IValidator<EducationInformationAdd>, EducationInformationAddValidator>();
            //services.AddTransient<IValidator<EducationInformationUpdate>, EducationInformationUpdateValidator>();

            ////services.AddTransient<IValidator<AddressAdd>, AddressAddValidator>();
            ////services.AddTransient<IValidator<AddressUpdate>, AddressUpdateValidator>();

            ////services.AddTransient<IValidator<AddressAdd>, AddressAddValidator>();
            ////services.AddTransient<IValidator<AddressUpdate>, AddressUpdateValidator>();

            ////services.AddTransient<IValidator<AddressAdd>, AddressAddValidator>();
            ////services.AddTransient<IValidator<AddressUpdate>, AddressUpdateValidator>();

            ////services.AddTransient<IValidator<AddressAdd>, AddressAddValidator>();
            ////services.AddTransient<IValidator<AddressUpdate>, AddressUpdateValidator>();

            //#endregion



            services.AddHttpContextAccessor();
            services.AddSession();

            #region ApiServices
            services.AddScoped<IProjectService, ProjectApiManager>();
            services.AddScoped<IAuthService, AuthApiManager>();
            services.AddScoped<IAddressService, AddressApiManager>();
            services.AddScoped<IBankInformationService, BankInformationApiManager>();
            services.AddScoped<IDepartmentService, DepartmentApiManager>();
            services.AddScoped<IEducationInformationService, EducationInformationApiManager>();
            services.AddScoped<IEmergencyContactInfoService, EmergencyContactInfoApiManager>();
            services.AddScoped<IExperienceService, ExperienceApiManager>();
            services.AddScoped<ILeaveService, LeaveApiManager>();
            services.AddScoped<IJobService, JobApiManager>();
            services.AddScoped<ILeaderService, LeaderApiManager>();
            services.AddScoped<IProjectService, ProjectApiManager>();
            services.AddScoped<ITaskService, TaskApiManager>();
            services.AddScoped<ITaskStatusService, TaskStatusApiManager>();
            services.AddScoped<IUserAssignmentService, UserAssignmentApiManager>();
            services.AddScoped<IUserSalaryService, UserSalaryApiManager>();
            services.AddScoped<IUserService, UserApiManager>();
            services.AddScoped<IRoleService, RoleApiManager>();
            #endregion

            services.AddControllersWithViews().AddFluentValidation();
            //services.AddControllersWithViews().AddFluentValidation(options =>
            //{
            //    options.RegisterValidatorsFromAssemblyContaining<Startup>();
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Privacy");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseStaticFiles();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
