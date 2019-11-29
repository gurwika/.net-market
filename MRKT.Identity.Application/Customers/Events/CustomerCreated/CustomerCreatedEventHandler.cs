using MediatR;
using MRKT.Common.Application.Common.Abstraction;
using MRKT.Common.Application.Common.Handlers;
using MRKT.Common.Application.Context.Abstraction;
using MRKT.Common.Domain.Common.Abstraction.Events;
using MRKT.Common.Domain.Entities.Identity;
using MRKT.Common.Domain.Entities.Identity.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MRKT.Identity.Application.Customers.Events.CustomerUpdated
{
    public class CustomerCreatedEventHandler : DomainEventHandler, IEventHandler<CustomerCreatedEvent>
    {
        public CustomerCreatedEventHandler(IApplicationDbContext context, IApplicationEventStore applicationEventStore) : base(context, applicationEventStore)
        {
        }

        public async Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
        {
            var cart = new Cart(
                Guid.NewGuid(),
                notification.Id
            );

            _context.Add(cart);

            _applicationEventStore.Store(notification);

            await SaveAndPublish(cancellationToken);
        }
    }
}
