using Hfttf.TaskManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hfttf.TaskManagement.Infrastructure.Mapping
{
    public class LeaveMap : IEntityTypeConfiguration<Leave>
    {
        public void Configure(EntityTypeBuilder<Leave> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Title).HasMaxLength(150).IsRequired();
            builder.Property(I => I.CreatedDate).HasColumnType("smalldatetime").IsRequired(false);
            builder.Property(I => I.UpdatedDate).HasColumnType("smalldatetime").IsRequired(false);
            builder.Property(I => I.StartDate).HasColumnType("smalldatetime");
            builder.Property(I => I.EndDate).HasColumnType("smalldatetime");

            builder.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.Leaves)
                    .HasForeignKey(d => d.ApplicationUserId);
        }
    }
}
