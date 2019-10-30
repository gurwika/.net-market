using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRKT.Common.Domain.Entities.Application;
using MRKT.Common.Domain.Entities.Payment;
using Newtonsoft.Json;

namespace MRKT.Common.Persistence.Configuration.Payment
{
    class OrderDatailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.Ignore(c => c.PendingEvents);

            builder.Property(p => p.TakeOutAddress)
                    .HasConversion(
                        takeOutAddress => JsonConvert.SerializeObject(takeOutAddress),
                        dbValue => JsonConvert.DeserializeObject<Address>(dbValue)
                    )
                .HasColumnType("json");

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