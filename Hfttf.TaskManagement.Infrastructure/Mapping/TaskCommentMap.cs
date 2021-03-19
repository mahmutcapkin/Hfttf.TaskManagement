using Hfttf.TaskManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hfttf.TaskManagement.Infrastructure.Mapping
{
    public class TaskCommentMap : IEntityTypeConfiguration<TaskComment>
    {
        public void Configure(EntityTypeBuilder<TaskComment> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Comment).HasMaxLength(250).IsRequired();
            builder.Property(I => I.CreatedDate).HasColumnType("smalldatetime").IsRequired(false);
            builder.Property(I => I.UpdatedDate).HasColumnType("smalldatetime").IsRequired(false);

            builder.HasOne(d => d.Task)
                .WithMany(p => p.TaskComments)
                .HasForeignKey(d => d.TaskId);
        }
    }
}
