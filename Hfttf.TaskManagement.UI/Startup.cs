using Hfttf.TaskManagement.UI.ApiServices.Concrete;
using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
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

            services.AddHttpContextAccessor();
            services.AddSession();

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

            services.AddControllersWithViews();
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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
