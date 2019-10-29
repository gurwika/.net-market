using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRKT.Common.Domain.Entities.Production;

namespace MRKT.Common.Persistence.Configuration.Production
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Ignore(c => c.PendingEvents);

            builder.Property(e => e.Caption)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(e => e.Brand)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.BrandId);
        }
    }
}
