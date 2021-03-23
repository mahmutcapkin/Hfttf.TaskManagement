using Hfttf.TaskManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hfttf.TaskManagement.Infrastructure.Mapping
{
    public class EducationInformationMap : IEntityTypeConfiguration<EducationInformation>
    {
    
        public void Configure(EntityTypeBuilder<EducationInformation> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(e => e.Section)
               .HasMaxLength(100)
               .IsUnicode(false);
            builder.Property(e => e.SchoolName)
              .HasMaxLength(200)
              .IsUnicode(false);

            builder.HasOne(d => d.ApplicationUser)
              .WithMany(p => p.EducationInformations)
              .HasForeignKey(d => d.ApplicationUserId);

        }
    }
}
