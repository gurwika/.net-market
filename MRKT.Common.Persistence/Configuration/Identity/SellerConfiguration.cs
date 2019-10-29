using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRKT.Common.Domain.Entities.Identity;

namespace MRKT.Common.Persistence.Configuration.Identity
{
    public class SellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.Ignore(c => c.PendingEvents);

            builder.Property(e => e.LegalName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.BusinessEmail)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.CompanyTaxId)
                .IsRequired()
                .HasMaxLength(12);
        }
    }
}