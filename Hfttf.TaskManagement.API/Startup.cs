using FluentValidation.AspNetCore;
using Hfttf.TaskManagement.API.Domain.Services;
using Hfttf.TaskManagement.API.Security.Token;
using Hfttf.TaskManagement.API.Services;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Infrastructure.Data.EntityFrameworkCore;
using Hfttf.TaskManagement.Service.ServiceExtensions;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using TokenHandler = Hfttf.TaskManagement.API.Security.Token.TokenHandler;

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
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserService, UserService>();


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


            #region DbContext

            services.AddCustomDbContext(Configuration["ConnectionStrings:Default"]);
            #endregion

            services.AddIdentity<ApplicationUser, ApplicationRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.User.AllowedUserNameCharacters = "abcçdefgðhýijklmnoçpqrsþtuüvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._";

                opts.Password.RequiredLength = 4;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<TaskManagementContext>();

            //services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            //{
            //    options.Password.RequireNonAlphanumeric = false; //buradaki optionslar loglamalar için imkan saðlýyor. 
            //})
            //  .AddEntityFrameworkStores<TaskManagementContext>()
            //  .AddDefaultTokenProviders();

            services.Configure<CustomTokenOptions>(Configuration.GetSection("TokenOptions"));
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<CustomTokenOptions>();

            //Adding Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                // options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            //Adding Jwt Bearer
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidateAudience = true,
                     ValidateIssuer = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = tokenOptions.Issuer,
                     ValidAudience = tokenOptions.Audience,
                     IssuerSigningKey = SignHandler.GetSecurityKey(tokenOptions.SecurityKey),
                     ClockSkew = TimeSpan.Zero
                 };
                //options.SaveToken = true;
                //options.RequireHttpsMetadata = false;
                //options.TokenValidationParameters = new TokenValidationParameters()
                //{
                //    ValidateIssuer = true,
                //    ValidateAudience = true,
                //    ValidAudience = Configuration["JWT:ValidAudience"],
                //    ValidIssuer = Configuration["JWT:ValidIssuer"],
                //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JWT:Secret"])),
                //};
            });



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hfttf.TaskManagement.API", Version = "v1" });
            });

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy", builder =>
            //    {
            //        builder.WithOrigins("http://localhost:5005").AllowAnyHeader().AllowAnyMethod().AllowCredentials();

            //    });
            //});
            services.AddCors(opts =>
            {

                opts.AddDefaultPolicy(builder =>
                {

                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
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
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

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

            app.UseStaticFiles();
            app.UseRouting();
            //app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
