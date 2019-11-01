using MRKT.Common.Domain.Common.Concrete.Aggregates;
using MRKT.Common.Domain.Entities.Production;
using MRKT.Common.Domain.Entities.Identity.Events;
using MRKT.Common.Domain.Entities.Selles.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MRKT.Common.Domain.Entities.Identity
{
    public class Brand: EventSourcedAggregate
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public string DisplayName { get; protected set; }
        public string Description { get; protected set; }
        public string LogoUrl { get; protected set; }
        public string PublicUrl { get; protected set; }
        public virtual Seller Seller { get; protected set; }
        public Guid SellerId { get; protected set; }

        public virtual ICollection<Product> Products { get; private set; }

        public Brand(Guid id, string displayName, string description, string publicUrl, Guid sellerId)
        {
            Id = id;
            DisplayName = displayName;
            Description = description;
            PublicUrl = publicUrl;
            SellerId = sellerId;

            RiseEvent(
                new BrandCreatedEvent(
                    Id,
                    JsonConvert.SerializeObject(this)
                )
            );
        }

        public void UpdateLogo(string logoUrl)
        {
            LogoUrl = logoUrl;

            RiseEvent(
                new BrandUpdatedEvent(
                    Id,
                    JsonConvert.SerializeObject(this)
                )
            );
        }

        public void Update(string displayName, string description, string publicUrl)
        {
            DisplayName = displayName;
            Description = description;
            PublicUrl = publicUrl;

            RiseEvent(
                new BrandUpdatedEvent(
                    Id,
                    JsonConvert.SerializeObject(this)
                )
            );
        }

        public void Delete()
        {
            DeletedAt = DateTime.Now;

            RiseEvent(new BrandDeletedEvent(Id));
        }
    }
}
