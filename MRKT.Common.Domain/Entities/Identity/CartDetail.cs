
using MRKT.Common.Domain.Common.Concrete.Aggregates;
using MRKT.Common.Domain.Entities.Identity.Events;
using MRKT.Common.Domain.Entities.Production;
using MRKT.Common.Domain.Enumarations.Cart;
using Newtonsoft.Json;
using System;

namespace MRKT.Common.Domain.Entities.Identity
{
    public class CartDetail : EventSourcedAggregate
    {
        public CartDetail()
        {
        }

        public virtual Stock Stock { get; protected set; }
        public Guid StockId { get; set; }
        public virtual Cart Cart { get; protected set; }
        public Guid CartId { get; set; }
        public int Quantity { get; protected set; }
        public CartDetailType Type { get; protected set; }

        public CartDetail(Guid id, Guid stockId, Guid cartId, int quantity)
        {
            Id = id;
            StockId = stockId;
            CartId = cartId;
            Quantity = quantity;

            RiseEvent(
                new CartDetailCreatedEvent(
                    Id,
                    JsonConvert.SerializeObject(this)
                )
            );
        }

        public void Update(int quantity)
        {
            Quantity = quantity;

            RiseEvent(
                new CartDetailUpdatedEvent(
                    Id,
                    JsonConvert.SerializeObject(this)
                )
            );
        }

        public void Delete()
        {
            DeletedAt = DateTime.Now;

            RiseEvent(new CartDetailDeletedEvent(Id));
        }
    }
}