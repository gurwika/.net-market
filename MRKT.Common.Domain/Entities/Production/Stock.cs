using MRKT.Common.Domain.Common.Abstraction.Events;
using MRKT.Common.Domain.Common.Concrete.Aggregates;
using MRKT.Common.Domain.Entities.Identity;
using MRKT.Common.Domain.Entities.Payment;
using MRKT.Common.Domain.Entities.Production.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MRKT.Common.Domain.Entities.Production
{
    public class Stock: EventSourcedAggregate
    {
        public Stock()
        {
            CartDetails = new HashSet<CartDetail>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public virtual ProductDetail ProductDetail { get; protected set; }
        public Guid ProductDetailId { get; protected set; }
        public string Sku { get; protected set; }
        public string Size { get; protected set; }
        public int Qunatity { get; protected set; }
        public int Price { get; protected set; }
        public bool CanPreOrder { get; protected set; }

        public virtual ICollection<CartDetail> CartDetails { get; private set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; private set; }
        public Stock(Guid id, string sku, string size, int qunatity, int price, bool canPreOrder, Guid productDetailId)
        {
            Id = id;
            Sku = sku;
            Size = size;
            Qunatity = qunatity;
            Price = price;
            CanPreOrder = canPreOrder;
            ProductDetailId = productDetailId;

            RiseEvent(
                new StockCreatedEvent(
                    Id,
                    JsonConvert.SerializeObject(this)
                )
            );
        }

        public void Update(string sku, string size, int price, bool canPreOrder)
        {
            Sku = sku;
            Size = size;
            Price = price;
            CanPreOrder = canPreOrder;

            RiseEvent(new StockUpdatedEvent(
                Id,
                JsonConvert.SerializeObject(this)
            ));
        }

        public void UpdateQunatity(int qunatity)
        {
            IEvent updateEvent = null;
            if(Qunatity == 0 && qunatity > 0)
            {
                Qunatity = qunatity;

                updateEvent = new ProductDetailInStockEvent(
                    Id,
                    JsonConvert.SerializeObject(this)
                );
            } else
            {
                Qunatity = qunatity;

                if (Qunatity == 0)
                {
                    updateEvent = new ProductDetailOutOfStockEvent(Id);
                }
                else
                {
                    updateEvent = new StockQuantityUpdatedEvent(
                        Id,
                        JsonConvert.SerializeObject(this)
                    );
                }
            }

            RiseEvent(updateEvent);
        }

        public void Delete()
        {
            DeletedAt = DateTime.Now;

            RiseEvent(new StockDeletedEvent(Id));
        }
    }
}
