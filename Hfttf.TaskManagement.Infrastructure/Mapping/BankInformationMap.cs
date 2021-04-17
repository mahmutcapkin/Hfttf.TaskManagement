using Hfttf.TaskManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hfttf.TaskManagement.Infrastructure.Mapping
{
    public class BankInformationMap : IEntityTypeConfiguration<BankInformation>
    {
        public void Configure(EntityTypeBuilder<BankInformation> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(e => e.BankName)
                  .HasMaxLength(50)
                  .IsUnicode(false);
            builder.Property(e => e.IBANNo)
                 .HasMaxLength(100)
                 .IsUnicode(false);
            builder.Property(e => e.AccountNo)
               .HasMaxLength(100)
               .IsUnicode(false);

            builder.HasOne(d => d.ApplicationUser)
             .WithMany(p => p.BankInformations)
             .HasForeignKey(d => d.ApplicationUserId);
        }
    }
}
