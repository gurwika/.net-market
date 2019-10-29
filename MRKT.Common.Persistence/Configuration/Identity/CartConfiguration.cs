using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRKT.Common.Domain.Entities.Application;
using MRKT.Common.Domain.Entities.Identity;

namespace MRKT.Common.Persistence.Configuration.Identity
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder) 
        {
            builder.Ignore(c => c.PendingEvents);
        }
    }
}
