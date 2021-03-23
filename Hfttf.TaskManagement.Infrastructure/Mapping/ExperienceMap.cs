using Hfttf.TaskManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hfttf.TaskManagement.Infrastructure.Mapping
{
    public class ExperienceMap : IEntityTypeConfiguration<Experience>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(e => e.Company)
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.Job)
                 .HasMaxLength(50)
                 .IsUnicode(false);

            builder.HasOne(d => d.ApplicationUser)
              .WithMany(p => p.Experiences)
              .HasForeignKey(d => d.ApplicationUserId);

        }
    }
}
