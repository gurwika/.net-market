using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRKT.Common.Domain.Entities.Production;

namespace MRKT.Common.Persistence.Configuration.Production
{
    class StockCondifuration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.Ignore(c => c.PendingEvents);

            builder.Property(e => e.Sku)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(e => e.Size)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(e => e.ProductDetail)
                .WithMany(e => e.Stocks)
                .HasForeignKey(e => e.ProductDetailId);
        }
    }
}