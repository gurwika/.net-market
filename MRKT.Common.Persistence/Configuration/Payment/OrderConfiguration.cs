using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRKT.Common.Domain.Entities.Application;
using MRKT.Common.Domain.Entities.Payment;
using Newtonsoft.Json;

namespace MRKT.Common.Persistence.Configuration.Payment
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Ignore(c => c.PendingEvents);

            builder.Property(e => e.OrderNumber)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.ShippingAddress)
                    .HasConversion(
                        shippingAddress => JsonConvert.SerializeObject(shippingAddress),
                        dbValue => JsonConvert.DeserializeObject<Address>(dbValue)
                    )
                .HasColumnType("json");

            builder.Property(p => p.BillingAddress)
                    .HasConversion(
                        billingAddress => JsonConvert.SerializeObject(billingAddress),
                        dbValue => JsonConvert.DeserializeObject<Address>(dbValue)
                    )
                .HasColumnType("json");

            builder.HasOne(e => e.Customer)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.CustomerId);
        }
    }
}
