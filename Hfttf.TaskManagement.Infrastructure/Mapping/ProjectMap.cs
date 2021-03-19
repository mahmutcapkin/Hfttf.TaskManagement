using Hfttf.TaskManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hfttf.TaskManagement.Infrastructure.Mapping
{
    public class ProjectMap : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Title).HasMaxLength(200).IsRequired();
            builder.Property(I => I.CreatedDate).HasColumnType("smalldatetime").IsRequired(false);
            builder.Property(I => I.UpdatedDate).HasColumnType("smalldatetime").IsRequired(false);
            builder.Property(I => I.EndDate).HasColumnType("smalldatetime");
            builder.Property(I => I.StartDate).HasColumnType("smalldatetime");
         
        }
    }
}
