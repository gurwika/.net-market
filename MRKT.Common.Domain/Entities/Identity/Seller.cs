using MRKT.Common.Domain.Common.Concrete.Aggregates;
using MRKT.Common.Domain.Entities.Application;
using MRKT.Common.Domain.Entities.Identity.Events;
using MRKT.Common.Domain.Entities.Payment;
using MRKT.Common.Domain.Enumarations.Seller;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MRKT.Common.Domain.Entities.Identity
{
    public class Seller : EventSourcedAggregate
    {
        public Seller()
        {
            OrderDetails = new HashSet<OrderDetail>();
            Brands = new HashSet<Brand>();
            Addresses = new HashSet<Address>();
        }

        public SellerType Type { get; protected set; }
        public SellerStatusType Status { get; protected set; }
        public string LegalName { get; protected set; }
        public string BusinessEmail { get; protected set; }
        public string CompanyTaxId { get; protected set; }
        public virtual ApplicationUser ApplicationUser { get; protected set; }
        public string ApplicationUserId { get; set; }
        
        public virtual ICollection<OrderDetail> OrderDetails { get; private set; }
        public virtual ICollection<Brand> Brands { get; private set; }
        public virtual ICollection<Address> Addresses { get; private set; }

        public Seller(Guid id, SellerType type, string legalName, string businessEmail, string companyTaxId, string applicationUserId)
        {
            Id = id;
            Type = type;
            LegalName = legalName;
            BusinessEmail = businessEmail;
            CompanyTaxId = companyTaxId;
            ApplicationUserId = applicationUserId;
            Status = SellerStatusType.INITIAL;

            RiseEvent(
                new SellerCreatedEvent(
                    Id,
                    JsonConvert.SerializeObject(this)
                )
            );
        }

        public void Update(string legalName, string businessEmail)
        {
            LegalName = legalName;
            BusinessEmail = businessEmail;

            RiseEvent(
                new SellerUpdatedEvent(
                    Id,
                    JsonConvert.SerializeObject(this)
                )
            );
        }

        public void Verify()
        {
            Status = SellerStatusType.VERIFIED;

            RiseEvent(new SellerVerifiedEvent(Id));
        }

        public void Suspend()
        {
            Status = SellerStatusType.SUSPENDED;

            RiseEvent(new SellerSuspendedEvent(Id));
        }

        public void Delete()
        {
            RiseEvent(new SellerDeletedEvent(Id));
        }
    }
}
