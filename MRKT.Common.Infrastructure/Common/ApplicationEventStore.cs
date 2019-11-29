using EventStore.ClientAPI;
using Microsoft.Extensions.Options;
using MRKT.Common.Application.Common.Abstraction;
using MRKT.Common.Application.Common.Options;
using MRKT.Common.Domain.Common.Abstraction.Events;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Text.Json.Serialization;

namespace MRKT.Common.Infrastructure.Common
{
    public class ApplicationEventStore : IApplicationEventStore
    {
        private readonly IOptions<EventStoreOptions> _eventStoreOption;
        private readonly ICurrentUserService _currentUserService;

        public ApplicationEventStore(
            IOptions<EventStoreOptions> eventStoreOptions, 
            ICurrentUserService currentUserService
        )
        {
            _eventStoreOption = eventStoreOptions;
            _currentUserService = currentUserService;
        }

        public void Store<TEvent>(TEvent @event) where TEvent : IEvent
        {
            using (var connection = EventStoreConnection.Create(_eventStoreOption.Value.ConnectionString))
            {
                connection.ConnectAsync().Wait();

                var eventToSave = new EventData(
                    @event.Id,
                    @event.GetType().Name,
                    true,
                    Encoding.UTF8.GetBytes(@event.Payload),
                    Encoding.UTF8.GetBytes(
                        JsonConvert.SerializeObject(new
                        {
                            Ip = _currentUserService.Ip,
                            UserId = _currentUserService.UserId
                        })
                    )
                );

                connection.AppendToStreamAsync(
                    _eventStoreOption.Value.StreamName,
                    ExpectedVersion.Any, eventToSave
                ).Wait();
            }
        }
    }
}
