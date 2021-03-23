using Hfttf.TaskManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hfttf.TaskManagement.Infrastructure.Mapping
{
    class UserAssignmentMap : IEntityTypeConfiguration<UserAssignment>
    {
        public void Configure(EntityTypeBuilder<UserAssignment> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.CreatedDate).HasColumnType("smalldatetime").IsRequired(false);
            builder.Property(I => I.UpdatedDate).HasColumnType("smalldatetime").IsRequired(false);

            builder.HasOne(d => d.ApplicationUser)
                   .WithMany(p => p.UserAssignments)
                   .HasForeignKey(d => d.ApplicationUserId);

            builder.HasOne(d => d.Task)
                .WithMany(p => p.UserAssignments)
                .HasForeignKey(d => d.TaskId);
        }
    }
}
