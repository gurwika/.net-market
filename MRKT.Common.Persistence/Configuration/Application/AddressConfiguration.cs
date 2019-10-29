using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRKT.Common.Domain.Entities.Application;
using MRKT.Common.Domain.ValueObjects;

namespace MRKT.Common.Persistence.Configuration.Application
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(e => e.Steet)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.Steet2)
                .HasMaxLength(30);

            builder.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.State)
                .HasMaxLength(30);

            builder.Property(e => e.Zipcode)
                .HasMaxLength(10);

            builder.Property(p => p.PhoneNumber)
                    .HasConversion(
                        phoneNumber => phoneNumber.ToString(),
                        dbValue => PhoneNumber.For(dbValue)
                    )
                .HasMaxLength(13);

            builder.HasOne(e => e.Customer)
                .WithMany(e => e.Addresses)
                .HasForeignKey(e => e.CustomerId);

            builder.HasOne(e => e.Seller)
                .WithMany(e => e.Addresses)
                .HasForeignKey(e => e.SellerId);
        }
    }
}
