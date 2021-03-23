using Hfttf.TaskManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hfttf.TaskManagement.Infrastructure.Mapping
{
    public class EmergencyContactInfoMap : IEntityTypeConfiguration<EmergencyContactInfo>
    {
     
        public void Configure(EntityTypeBuilder<EmergencyContactInfo> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.RelationShip)
                   .HasMaxLength(20)
                   .IsUnicode(false);

            builder.Property(e => e.Phone)
                     .HasMaxLength(20)
                     .IsUnicode(false);

            builder.HasOne(d => d.ApplicationUser)
               .WithMany(p => p.EmergencyContactInfos)
               .HasForeignKey(d => d.ApplicationUserId);

        }
    }
}
