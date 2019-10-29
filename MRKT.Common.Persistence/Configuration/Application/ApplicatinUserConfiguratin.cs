using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRKT.Common.Domain.Entities.Application;
using MRKT.Common.Domain.Entities.Identity;

namespace MRKT.Common.Persistence.Configuration.Application
{
    public class ApplicationUserConfiguratin : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(e => e.PersonalId)
                .IsRequired()
                .HasMaxLength(11);

            builder.HasOne(e => e.Seller)
                .WithOne(e => e.ApplicationUser)
                .HasForeignKey<Seller>(e => e.ApplicationUserId);

            builder.HasOne(e => e.Customer)
                .WithOne(e => e.ApplicationUser)
                .HasForeignKey<Customer>(e => e.ApplicationUserId);
        }
    }
}
