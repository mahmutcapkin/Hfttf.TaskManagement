using FluentValidation.AspNetCore;
using Hfttf.TaskManagement.Service.ServiceExtensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Hfttf.TaskManagement.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            #region DbContext

            services.AddCustomDbContext(Configuration["ConnectionStrings:Default"]);
            #endregion

            #region Dependency Injections
            services.AddContainerWithDependencies();
            #endregion
            #region AutoMapper
            services.AddAutoMapper(typeof(Startup));
            #endregion
            #region Mediatr
            services.AddMediatR(typeof(Startup));
            services.AddCustomMediatR();
            #endregion

            #region Domain Level Validation
            services.AddControllersWithViews().AddFluentValidation();
            services.AddDomainLevelValidation();
            #endregion

            #region Use NewtonJsonSoft
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hfttf.TaskManagement.API", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins("http://localhost:5003").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                                                         
                });
            });


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
              
            }

            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseSwagger(c =>
            {
                c.RouteTemplate = "/task-management-swagger/{documentName}/task-management-swagger.json";
            });

            app.UseSwaggerUI(
               c =>
               {
                   c.SwaggerEndpoint("/task-management-swagger/v1/task-management-swagger.json", "Hfttf.TaskManagement.API v1");
                   c.RoutePrefix = "task-management-swagger";
               });

        }
    }
}
