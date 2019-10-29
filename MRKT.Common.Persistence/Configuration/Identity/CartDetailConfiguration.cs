using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRKT.Common.Domain.Entities.Application;
using MRKT.Common.Domain.Entities.Identity;

namespace MRKT.Common.Persistence.Configuration.Identity
{
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.Ignore(c => c.PendingEvents);

            builder.HasOne(e => e.Stock)
                .WithMany(e => e.CartDetails)
                .HasForeignKey(e => e.StockId);

            builder.HasOne(e => e.Cart)
                .WithMany(e => e.CartDetails)
                .HasForeignKey(e => e.CartId);
        }
    }
}
