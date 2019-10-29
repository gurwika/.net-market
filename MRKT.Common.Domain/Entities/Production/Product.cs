using MRKT.Common.Domain.Common.Concrete.Aggregates;
using MRKT.Common.Domain.Entities.Production.Events;
using MRKT.Common.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MRKT.Common.Domain.Entities.Production
{
    public class Product : EventSourcedAggregate
    {
        public Product()
        {
            CreatedAt = DateTime.Now;
            ProductDetails = new HashSet<ProductDetail>();
        }

        public string Caption { get; protected set; }
        public bool Published { get; protected set; }
        public virtual Brand Brand { get; protected set; }
        public Guid BrandId { get; protected set; }

        public virtual ICollection<ProductDetail> ProductDetails { get; private set; }

        public Product(Guid id, string caption, Guid brandId)
        {
            Id = id;
            Caption = caption;
            BrandId = brandId;
            Published = false;
            CreatedAt = DateTime.Now;

            RiseEvent(
                new ProductCreatedEvent(
                    Id,
                    JsonConvert.SerializeObject(this)
                )
            );
        }

        public void Update(string caption, Brand brand)
        {
            Caption = caption;
            Brand = brand;
            LastModified = DateTime.Now;

            RiseEvent(
                new ProductUpdatedEvent(
                    Id,
                    JsonConvert.SerializeObject(this)
                )
            );
        }

        public void Publish()
        {
            Published = true;
            LastModified = DateTime.Now;

            RiseEvent(new ProductPublishedEvent(Id));
        }

        public void UnPublish()
        {
            Published = false;
            LastModified = DateTime.Now;

            RiseEvent(new ProductUnPublishedEvent(Id));
        }

        public void Delete()
        {
            DeletedAt = DateTime.Now;

            RiseEvent(new ProductDeletedEvent(Id));
        }
    }
}
