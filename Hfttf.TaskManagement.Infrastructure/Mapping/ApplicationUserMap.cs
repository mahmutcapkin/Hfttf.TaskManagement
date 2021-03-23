using Hfttf.TaskManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hfttf.TaskManagement.Infrastructure.Mapping
{
    public class ApplicationUserMap : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.BirthDate).HasColumnType("smalldatetime").IsRequired(false);

            builder.Property(e => e.FirstName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

            builder.Property(e => e.LastName)
                  .HasMaxLength(25)
                  .IsUnicode(false);

            builder.HasOne(d => d.Department)
                     .WithMany(p => p.ApplicationUsers)
                     .HasForeignKey(d => d.DepartmentId);
        }
    }
}
