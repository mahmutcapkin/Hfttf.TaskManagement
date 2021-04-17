using Hfttf.TaskManagement.Infrastructure.Data.EntityFrameworkCore;
using Hfttf.TaskManagement.Infrastructure.Data.SeedData;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.API
{
    public class Program
    {

        /*ESKÝ HALÝ*/
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        /*---------------------------------------------------------------*/

        //public static void Main(string[] args)
        //{
        //    var host = CreateHostBuilder(args).Build();
        //    CreateAndSeedDatabaseAsync(host);
        //    host.Run();
        //}

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });

        //private static async Task CreateAndSeedDatabaseAsync(IHost host)
        //{
        //    using (var scope = host.Services.CreateScope())
        //    {
        //        var services = scope.ServiceProvider;
        //        var loggerFactory = services.GetRequiredService<ILoggerFactory>();

        //        try
        //        {
        //            var context = services.GetRequiredService<TaskManagementContext>();
        //            await SeedDatabase.SeedAsync(context, loggerFactory);
        //        }
        //        catch (Exception exception)
        //        {
        //            var logger = loggerFactory.CreateLogger<Program>();
        //            logger.LogError(exception.Message);
        //        }
        //    }
        //}

    }
}
