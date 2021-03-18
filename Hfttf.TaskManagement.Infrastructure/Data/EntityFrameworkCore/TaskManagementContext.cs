using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Infrastructure.Mapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hfttf.TaskManagement.Infrastructure.Data.EntityFrameworkCore
{
    public class TaskManagementContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public TaskManagementContext(DbContextOptions<TaskManagementContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Config all mapping class
            modelBuilder.ApplyConfiguration(new AddressMap());         
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Address> Addresses { get; set; }

    }
}
