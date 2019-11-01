using MRKT.Common.Domain.Common.Concrete.Aggregates;
using MRKT.Common.Domain.Entities.Application;
using MRKT.Common.Domain.Entities.Identity;
using MRKT.Common.Domain.Entities.Payments.Events;
using MRKT.Common.Domain.Entities.Production;
using MRKT.Common.Domain.Enumarations.Payment;
using Newtonsoft.Json;
using System;

namespace MRKT.Common.Domain.Entities.Payment
{
    public class OrderDetail : EventSourcedAggregate
    {
        public OrderDetail()
        {
        }

        public virtual Seller Seller { get; protected set; }
        public Guid SellerId { get; set; }
        public virtual Stock Stock { get; protected set; }
        public Guid StockId { get; set; }
        public virtual Order Order { get; protected set; }
        public Guid OrderId { get; set; }
        public double Price { get; protected set; }
        public int ShippingPrice { get; protected set; }
        public int Quantity { get; protected set; }
        public OrderDetailStatusType Status { get; protected set; }
        public Address TakeOutAddress { get; protected set; }

        public OrderDetail(Guid id, Guid stockId, Guid orderId, int price, int shippingPrice, int quantity, Address takeOutAddress)
        {
            Id = id;
            Price = price;
            ShippingPrice = shippingPrice;
            Quantity = quantity;
            TakeOutAddress = takeOutAddress;
            StockId = stockId;
            OrderId = orderId;

            Status = OrderDetailStatusType.PROCESSING;

            RiseEvent(
                new OrderDetailCreatedEevent(
                    Id,
                    JsonConvert.SerializeObject(this)
                )
            );
        }
    }
}
