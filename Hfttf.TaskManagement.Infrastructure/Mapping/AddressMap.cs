using Hfttf.TaskManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hfttf.TaskManagement.Infrastructure.Mapping
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(e => e.City)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            builder.Property(e => e.Country)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            builder.Property(e => e.Description)
                  .IsRequired()
                  .HasMaxLength(500)
                  .IsUnicode(false);
            builder.Property(e => e.ZipCode)
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.HasOne(I => I.ApplicationUser)
                    .WithMany(I => I.Addresses)
                    .HasForeignKey(d => d.ApplicationUserId);
        }
    }
}
