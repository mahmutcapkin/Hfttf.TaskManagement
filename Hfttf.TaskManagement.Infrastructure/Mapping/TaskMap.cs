using Hfttf.TaskManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hfttf.TaskManagement.Infrastructure.Mapping
{
    public class TaskMap : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Title).HasMaxLength(50).IsRequired();
            builder.Property(I => I.DueDate).HasColumnType("smalldatetime");
            builder.Property(I => I.CreatedDate).HasColumnType("smalldatetime").IsRequired(false);
            builder.Property(I => I.UpdatedDate).HasColumnType("smalldatetime").IsRequired(false);

            builder.Property(e => e.Description)
                 .HasMaxLength(1000)
                 .IsUnicode(false);

            builder.HasOne(d => d.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ProjectId);

            builder.HasOne(d => d.TaskStatus)
                .WithMany(p => p.Tasks)
                .HasForeignKey(d => d.TaskStatusId);
        }
    }
}
