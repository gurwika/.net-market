using MRKT.Common.Domain.Common.Concrete.Aggregates;
using MRKT.Common.Domain.Entities.Identity.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MRKT.Common.Domain.Entities.Identity
{
    public class Cart: EventSourcedAggregate
    {
        public Cart()
        {
            CreatedAt = DateTime.Now;
            CartDetails = new HashSet<CartDetail>();
        }

        public virtual Customer Customer { get; protected set; }
        public Guid CustomerId { get; set; }
        
        public virtual ICollection<CartDetail> CartDetails { get; private set; }
        
        public Cart(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
            CreatedAt = DateTime.Now;

            RiseEvent(
                new CartCreatedEvent(
                    Id,
                    JsonConvert.SerializeObject(this)
                )
            );
        }
    }
}
