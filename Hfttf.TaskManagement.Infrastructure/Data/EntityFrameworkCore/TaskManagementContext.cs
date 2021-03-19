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
            modelBuilder.ApplyConfiguration(new TaskCommentMap());
            modelBuilder.ApplyConfiguration(new TaskMap());
            modelBuilder.ApplyConfiguration(new TaskStatusMap());

            modelBuilder.ApplyConfiguration(new EmergencyContactInfoMap());
            modelBuilder.ApplyConfiguration(new ExperienceMap());
            modelBuilder.ApplyConfiguration(new BankInformationMap());
            modelBuilder.ApplyConfiguration(new EducationInformationMap());
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
        public DbSet<TaskComment> TaskComments { get; set; }
        public DbSet<TaskStatus> TaskStatuses { get; set; }

        public DbSet<EmergencyContactInfo> EmergencyContactInfos { get; set; }
        public DbSet<BankInformation> BankInformations { get; set; }
        public DbSet<EducationInformation> EducationInformations { get; set; }
        public DbSet<Experience> Experiences { get; set; }

    }
}
