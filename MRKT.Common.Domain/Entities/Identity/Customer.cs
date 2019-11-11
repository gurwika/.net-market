using MRKT.Common.Domain.Common.Concrete.Aggregates;
using MRKT.Common.Domain.Entities.Application;
using MRKT.Common.Domain.Entities.Identity.Events;
using MRKT.Common.Domain.Entities.Payment;
using MRKT.Common.Domain.Enumarations.Customer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MRKT.Common.Domain.Entities.Identity
{
    public class Customer : EventSourcedAggregate
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
            Addresses = new HashSet<Address>();
        }

        public CustomerGender Gender { get; protected set; }
        public DateTime BirthDate { get; protected set; }
        public virtual ApplicationUser ApplicationUser { get; protected set; }
        public string ApplicationUserId { get; set; }

        public virtual Cart Cart { get; protected set; }
        public virtual ICollection<Order> Orders { get; private set; }
        public virtual ICollection<Address> Addresses { get; private set; }

        public Customer(Guid id, CustomerGender gender, DateTime birthDate, string applicationUserId)
        {
            Id = id;
            Gender = gender;
            BirthDate = birthDate;
            ApplicationUserId = applicationUserId;

            RiseEvent(
                new CustomerCreatedEvent(
                    Id,
                    JsonConvert.SerializeObject(this)
                )
            ); 
        }

        public void Update(string email, string name, CustomerGender gender, DateTime birthDate)
        {
            Gender = gender;
            BirthDate = birthDate;

            RiseEvent(
                new CustomerUpdatedEvent(
                    Id,
                    JsonConvert.SerializeObject(this)
                )
            ); 
        }

        public void Delete()
        {
            DeletedAt = DateTime.Now;

            RiseEvent(new CustomerDeletedEvent(Id));
        }
    }
}
