using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRKT.Common.Domain.Entities.Production;

namespace MRKT.Common.Persistence.Configuration.Production
{
    class ProductDetailConfiguratin : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.Ignore(c => c.PendingEvents);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.ThumbnailUrl)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Info)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(e => e.Product)
                .WithMany(e => e.ProductDetails)
                .HasForeignKey(e => e.ProductId);
        }
    }
}