using Hfttf.TaskManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hfttf.TaskManagement.Infrastructure.Mapping
{
    public class UserSalaryMap : IEntityTypeConfiguration<UserSalary>
    {
        public void Configure(EntityTypeBuilder<UserSalary> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.CreatedDate).HasColumnType("smalldatetime").IsRequired(false);
            builder.Property(I => I.UpdatedDate).HasColumnType("smalldatetime").IsRequired(false);

            builder.Property(e => e.Salary).HasColumnType("decimal(18, 0)");

            builder.HasOne(d => d.ApplicationUser)
                .WithMany(p => p.UserSalaries)
                .HasForeignKey(d => d.ApplicationUserId);
        }
    }
}
