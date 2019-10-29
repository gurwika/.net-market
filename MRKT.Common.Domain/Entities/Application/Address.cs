using MRKT.Common.Domain.Common.Concrete.Aggregates;
using MRKT.Common.Domain.Entities.Identity;
using MRKT.Common.Domain.Entities.Payment;
using MRKT.Common.Domain.Enumarations.Application;
using MRKT.Common.Domain.ValueObjects;
using System;

namespace MRKT.Common.Domain.Entities.Application
{
    public class Address: Aggregate
    {
        public Address()
        {
            CreatedAt = DateTime.Now;
        }

        public AddressType Type { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Steet { get; protected set; }
        public string Steet2 { get; protected set; }
        public string City { get; protected set; }
        public string State { get; protected set; }
        public string Zipcode { get; protected set; }
        public PhoneNumber PhoneNumber { get; protected set; }
        public virtual Seller Seller { get; set; }
        public Guid? SellerId { get; set; }
        public virtual Customer Customer { get; set; }
        public Guid? CustomerId { get; set; }

        public Address(Guid id, string firstName, string lastName, string steet, string steet2, string city, string state, string zipcode, PhoneNumber phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Steet = steet;
            Steet2 = steet2;
            City = city;
            State = state;
            Zipcode = zipcode;
            PhoneNumber = phoneNumber;
            CreatedAt = DateTime.Now;
        }

        public void Update(string firstName, string lastName, string steet, string steet2, string city, string state, string zipcode, PhoneNumber phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Steet = steet;
            Steet2 = steet2;
            City = city;
            State = state;
            Zipcode = zipcode;
            PhoneNumber = phoneNumber;
            LastModified = DateTime.Now;
        }

        public void setCustomer(Guid customerId)
        {
            CustomerId = customerId;
        }

        public void setSeller(Guid sellerId)
        {
            SellerId = sellerId;
        }

        public void Delete()
        {
            DeletedAt = DateTime.Now;
        }
    }
}
