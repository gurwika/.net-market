using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRKT.Common.Domain.Entities.Payment;

namespace MRKT.Common.Persistence.Configuration.Payment
{
    class OrderDatailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.Ignore(c => c.PendingEvents);

            builder.Ignore(x => x.TakeOutAddress);
            builder.Property<string>("_takeOutAddressJson").HasField("_takeOutAddressJson").HasColumnName("TakeOutAddressJson").HasColumnType("json");

            builder.HasOne(e => e.Stock)
                .WithMany(e => e.OrderDetails)
                .HasForeignKey(e => e.StockId);

            builder.HasOne(e => e.Seller)
                .WithMany(e => e.OrderDetails)
                .HasForeignKey(e => e.SellerId);

            builder.HasOne(e => e.Order)
                .WithMany(e => e.OrderDetails)
                .HasForeignKey(e => e.OrderId);
        }
    }
}