using MRKT.Common.Domain.Common.Concrete.Aggregates;
using MRKT.Common.Domain.Entities.Production.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MRKT.Common.Domain.Entities.Production
{
    public class ProductDetail: EventSourcedAggregate
    {
        public ProductDetail()
        {
            Stocks = new HashSet<Stock>();
        }

        public virtual Product Product { get; protected set; }
        public Guid ProductId { get; protected set; }
        public string Name { get; protected set; }
        public string ThumbnailUrl { get; protected set; }
        public string Info { get; protected set; }
        
        public virtual ICollection<Stock> Stocks { get; private set; }

        public ProductDetail(Guid id, string name, string thumbnailUrl, string info, Guid productId)
        {
            Id = id;
            Name = name;
            ThumbnailUrl = thumbnailUrl;
            Info = info;
            ProductId = productId;

            RiseEvent(
                new ProductDetailCreatedEvent(
                    Id,
                    JsonConvert.SerializeObject(this)
                )
            );
        }

        public void Update(string name, string thumbnailUrl, string info)
        {
            Name = name;
            ThumbnailUrl = thumbnailUrl;
            Info = info;

            RiseEvent(new ProductDetailUpdatedEvent(
                Id,
                JsonConvert.SerializeObject(this)
            ));
        }

        public void Delete()
        {
            DeletedAt = DateTime.Now;

            RiseEvent(new ProductDetailDeletedEvent(Id));
        }
    }
}
