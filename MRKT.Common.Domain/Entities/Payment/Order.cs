using MRKT.Common.Domain.Common.Concrete.Aggregates;
using MRKT.Common.Domain.Entities.Application;
using MRKT.Common.Domain.Entities.Identity;
using MRKT.Common.Domain.Entities.Payments.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MRKT.Common.Domain.Entities.Payment
{
    public class Order: EventSourcedAggregate
    {
        public Order()
        {
            CreatedAt = DateTime.Now;
            OrderDetails = new HashSet<OrderDetail>();
        }

        public string OrderNumber { get; protected set; }
        public virtual Customer Customer { get; protected set; }
        public Guid CustomerId { get; set; }
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; private set; }

        public Order(Guid id, string orderNumber, Guid customerId, Address shippingAddress, Address billingAddress)
        {
            Id = id;
            OrderNumber = orderNumber;
            CustomerId = customerId;
            BillingAddress = billingAddress;
            ShippingAddress = shippingAddress;
            CreatedAt = DateTime.Now;

            RiseEvent(
                new OrderCreatedEvent(
                    Id,
                    JsonConvert.SerializeObject(this)
                )
            );
        }

        public void Delete()
        {
            DeletedAt = DateTime.Now;

            RiseEvent(new OrderDeletedEvent(Id));
        }
    }
}
