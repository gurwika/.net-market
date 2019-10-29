using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRKT.Common.Domain.Entities.Payment;

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
            
            builder.Ignore(x => x.ShippingAddress);
            builder.Property<string>("_shippingAddressJson").HasField("_shippingAddressJson").HasColumnName("ShippingAddressJson").HasColumnType("json");

            builder.Ignore(x => x.BillingAddress);
            builder.Property<string>("_billingAddressJson").HasField("_billingAddressJson").HasColumnName("BillingAddressJson").HasColumnType("json");


            builder.HasOne(e => e.Customer)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.CustomerId);
        }
    }
}
