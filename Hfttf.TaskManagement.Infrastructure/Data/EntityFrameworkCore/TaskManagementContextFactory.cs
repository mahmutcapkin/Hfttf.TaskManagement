using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Hfttf.TaskManagement.Infrastructure.Data.EntityFrameworkCore
{
    public class TaskManagementContextFactory : IDesignTimeDbContextFactory<TaskManagementContext>
    {
        public TaskManagementContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TaskManagementContext>();

            // var configuration = _serviceScope.ServiceProvider.GetRequiredService<IConfiguration>();
            // var connectionString = configuration.GetConnectionString("Default");
            builder.UseSqlServer("Data Source=DESKTOP-T9LQCB1;Database=TaskManagement;Integrated Security=True;",                     
                optionsBuilder =>
                {
                    optionsBuilder.MigrationsAssembly(typeof(TaskManagementContext).GetTypeInfo().Assembly.GetName().Name);
                    optionsBuilder.EnableRetryOnFailure(5);
                });
            return new TaskManagementContext(builder.Options);
        }
    }
}
