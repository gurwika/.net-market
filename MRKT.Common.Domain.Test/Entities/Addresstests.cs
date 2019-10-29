using MRKT.Common.Domain.Entities.Application;
using MRKT.Common.Domain.ValueObjects;
using System;
using Xunit;

namespace MRKT.Common.Domain.Test.Entities
{
    public class Addresstests
    {
        [Fact]
        public void ShouldMatchAllCreatedAddressFileds()
        {
            var address = new Address(
                Guid.NewGuid(), 
                "Giorgi",
                "Gurtsishvili",
                "11 Khevdzmari street",
                "Temqa",
                "Tbilisi",
                "Tbilisi",
                "0153",
                (PhoneNumber)"577-348094"
            );

            Assert.Equal("Giorgi", address.FirstName);
            Assert.Equal("Gurtsishvili", address.LastName);
            Assert.Equal("11 Khevdzmari street", address.Steet);
            Assert.Equal("Temqa", address.Steet2);
            Assert.Equal("Tbilisi", address.State);
            Assert.Equal("Tbilisi", address.City);
            Assert.Equal("0153", address.Zipcode);
            Assert.Equal((PhoneNumber)"577-348094", address.PhoneNumber);
        }

        [Fact]
        public void ShouldMatchAllUpdatesAddressFileds()
        {
            var address = new Address(
                Guid.NewGuid(),
                "Empty First Name",
                "Empty Last Name",
                "Empty Street",
                "Empty Street 2",
                "Empty State",
                "Empty City",
                "Empty Zip",
                (PhoneNumber)"000-000000"
            );

            address.Update("Giorgi",
                "Gurtsishvili",
                "11 Khevdzmari street",
                "Temqa",
                "Tbilisi",
                "Tbilisi",
                "0153",
                (PhoneNumber)"577-348094"
            );

            Assert.Equal("Giorgi", address.FirstName);
            Assert.Equal("Gurtsishvili", address.LastName);
            Assert.Equal("11 Khevdzmari street", address.Steet);
            Assert.Equal("Temqa", address.Steet2);
            Assert.Equal("Tbilisi", address.State);
            Assert.Equal("Tbilisi", address.City);
            Assert.Equal("0153", address.Zipcode);
            Assert.Equal((PhoneNumber)"577-348094", address.PhoneNumber);
        }

        [Fact]
        public void ShouldDeleteAddresss()
        {
            var address = new Address(
                Guid.NewGuid(),
                "Empty First Name",
                "Empty Last Name",
                "Empty Street",
                "Empty Street 2",
                "Empty State",
                "Empty City",
                "Empty Zip",
                (PhoneNumber)"000-000000"
            );

            address.Delete();

            Assert.NotNull(address.DeletedAt);
        }
    }
}
