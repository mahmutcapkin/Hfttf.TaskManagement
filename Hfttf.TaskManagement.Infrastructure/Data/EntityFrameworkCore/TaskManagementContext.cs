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
            modelBuilder.ApplyConfiguration(new DepartmentMap());
            modelBuilder.ApplyConfiguration(new JobMap());
            modelBuilder.ApplyConfiguration(new UserSalaryMap());
            modelBuilder.ApplyConfiguration(new HolidayMap());
            modelBuilder.ApplyConfiguration(new ProjectMap());
            modelBuilder.ApplyConfiguration(new UserAssignmentMap());
            modelBuilder.ApplyConfiguration(new TaskMap());
            modelBuilder.ApplyConfiguration(new TaskStatusMap());

            modelBuilder.ApplyConfiguration(new EmergencyContactInfoMap());
            modelBuilder.ApplyConfiguration(new ExperienceMap());
            modelBuilder.ApplyConfiguration(new BankInformationMap());
            modelBuilder.ApplyConfiguration(new EducationInformationMap());

            modelBuilder.ApplyConfiguration(new ApplicationUserMap());

            modelBuilder.ApplyConfiguration(new LeaderMap());

            modelBuilder.Entity<Leader>()
                        .HasOne<Project>(ad => ad.Project)
                        .WithOne(s => s.Leader)
                        .HasForeignKey<Project>(ad => ad.LeaderId);

            modelBuilder.Entity<Project>()
                        .HasOne<Leader>(ad => ad.Leader)
                        .WithOne(s => s.Project)
                        .HasForeignKey<Leader>(ad => ad.ProjectId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Job> Jobs { get; set; }     
        public DbSet<UserSalary> UserSalaries { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<UserAssignment> UserAssignments { get; set; }
        public DbSet<TaskStatus> TaskStatuses { get; set; }

        public DbSet<EmergencyContactInfo> EmergencyContactInfos { get; set; }
        public DbSet<BankInformation> BankInformations { get; set; }
        public DbSet<EducationInformation> EducationInformations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Leader> Leaders { get; set; }

    }
}
