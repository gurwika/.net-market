using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRKT.Common.Domain.Entities.Identity;

namespace MRKT.Common.Persistence.Configuration.Identity
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Ignore(c => c.PendingEvents);

            builder.Property(e => e.DisplayName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.LogoUrl)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.PublicUrl)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(e => e.Seller)
                .WithMany(e => e.Brands)
                .HasForeignKey(e => e.SellerId);
        }
    }
}