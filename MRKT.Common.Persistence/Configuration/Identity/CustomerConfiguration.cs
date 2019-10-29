using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRKT.Common.Domain.Entities.Identity;

namespace MRKT.Common.Persistence.Configuration.Identity
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Ignore(c => c.PendingEvents);

            builder.HasOne(e => e.Cart)
                .WithOne(e => e.Customer)
                .HasForeignKey<Cart>(e => e.CustomerId);
        }
    }
}
