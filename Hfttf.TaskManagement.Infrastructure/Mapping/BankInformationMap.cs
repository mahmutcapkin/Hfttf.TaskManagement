using Hfttf.TaskManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hfttf.TaskManagement.Infrastructure.Mapping
{
    public class BankInformationMap : IEntityTypeConfiguration<BankInformation>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<BankInformation> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            //builder.HasOne(d => d.ApplicationUser)
            // .WithMany(p => p.BankInformations)
            // .HasForeignKey(d => d.ApplicationUserId);
        }
    }
}
