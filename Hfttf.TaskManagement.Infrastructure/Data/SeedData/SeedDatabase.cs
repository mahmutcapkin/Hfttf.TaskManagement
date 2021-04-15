using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Infrastructure.Data.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace Hfttf.TaskManagement.Infrastructure.Data.SeedData
{
    public class SeedDatabase
    {
        public static async Task SeedAsync(TaskManagementContext context, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                context.Database.Migrate();

                if (!context.Addresses.Any())
                {
                    context.Addresses.AddRange(GetAddresses());
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception exception)
            {

                if (retryForAvailability < 5)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<SeedDatabase>();
                    log.LogError(exception.Message);
                    System.Threading.Thread.Sleep(1000);
                    await SeedAsync(context, loggerFactory, retryForAvailability);
                }
            }
        }
        private static IEnumerable<Address> GetAddresses()
        {
            return new List<Address>
            {
                new Address() { City="İstanbul", Country="Türkiye",  Description="Orta Mah, Demirkapı Cd. No:13, Bayrampaşa/İstanbul"  },
                new Address() { City="İstanbul", Country="Türkiye",  Description="Mimar Kemalettin, Ordu Cd. No:7, Fatih/İstanbul"  },
                new Address() { City="İstanbul", Country="Türkiye",  Description="Yeni, Cengiz Topel Cd. No:173, Gaziosmanpaşa/İstanbul"  },
                new Address() { City="İzmir",    Country="Türkiye",  Description="Bozyaka, Eski İzmir Cd. No:211,Karabağlar/İzmir"  },
                new Address() { City="İzmir",    Country="Türkiye",  Description="Akdeniz, Gazi Blv. No:41, Konak/İzmir"  },
            };
        }
    }
}
