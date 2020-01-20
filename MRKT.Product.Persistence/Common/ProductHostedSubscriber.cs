using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MRKT.Common.Application.Common.Abstraction;
using MRKT.Common.Domain.Entities.Identity.Events;
using MRKT.Common.Domain.Enumarations.Application;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MRKT.Identity.Persistence.Common
{
    public class ProductHostedSubscriber : IHostedService, IDisposable
    {
        private readonly IServiceProvider _services;

        public ProductHostedSubscriber(IServiceProvider services)
        {
            _services = services;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _services.CreateScope())
            {
                scope.ServiceProvider
                    .GetRequiredService<IApplicationEventSubscription>()
                        .Subscribe(EventSubscriberType.Production, new List<string> { typeof(CustomerCreatedEvent).Name });
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
