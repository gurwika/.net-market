using EventStore.ClientAPI;
using EventStore.ClientAPI.SystemData;
using MediatR;
using Microsoft.Extensions.Options;
using MRKT.Common.Application.Common.Abstraction;
using MRKT.Common.Application.Common.Options;
using MRKT.Common.Domain.Enumarations.Application;
using MRKT.Common.Infrastructure.Utils;
using System;
using System.Collections.Generic;

namespace MRKT.Common.Infrastructure.Common
{
    public class ApplicationEventSubscription : IApplicationEventSubscription
    {
        private readonly IMediator _mediator;
        private readonly IStoredEventSerializer _storedEventSerializer;
        private readonly IOptions<EventStoreOptions> _eventStoreOption;
        private readonly IEventStorePositionService _eventStorePositionService;
        
        public ApplicationEventSubscription(
            IMediator mediator,
            IOptions<EventStoreOptions> eventStoreOptions,
            IEventStorePositionService eventStorePositionService,
            IStoredEventSerializer storedEventSerializer
        )
        {
            _mediator = mediator;
            _eventStoreOption = eventStoreOptions;
            _storedEventSerializer = storedEventSerializer;
            _eventStorePositionService = eventStorePositionService;
        }

        public void Subscribe(EventSubscriberType eventSubscriberType, List<string> eventsToHandle)
        {
            var catchUpSettings = new CatchUpSubscriptionSettings(10, 500, true, false);
            var position = _eventStorePositionService.GetLastPosition(eventSubscriberType);
            var userCredentials = new UserCredentials(_eventStoreOption.Value.Username, _eventStoreOption.Value.Password);

            using (var _eventStoreConnection = EventStoreConnection.Create(_eventStoreOption.Value.ConnectionString))
            {
                _eventStoreConnection.ConnectAsync().Wait();

                _eventStoreConnection.SubscribeToAllFrom(
                    position,
                    catchUpSettings,
                    eventAppeared: async (EventStoreCatchUpSubscription sub, ResolvedEvent resolvedEvent) =>
                    {
                        if (resolvedEvent.OriginalStreamId.StartsWith("$"))
                            return;

                        if (resolvedEvent.Event.Data.Length <= 0)
                            return;

                        if (eventsToHandle.IsNotNull() && !eventsToHandle.Contains(resolvedEvent.Event.EventType))
                            return;

                        try {
                            await _eventStorePositionService.StoreLastPosition(
                                eventSubscriberType,
                                resolvedEvent.OriginalPosition.Value.CommitPosition,
                                resolvedEvent.OriginalPosition.Value.PreparePosition
                            );

                            var @event = _storedEventSerializer.As(resolvedEvent.Event.EventType, resolvedEvent.Event.Data);

                            if (@event == null)
                                return;

                            await _mediator.Publish(@event);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }, 
                    userCredentials: userCredentials, 
                    subscriptionDropped: (x, b, n) =>
                    {
                        Console.WriteLine(n.ToString());
                    }
                );

                Console.WriteLine("waiting for events. press enter to exit");
                Console.ReadLine();
            }
        }
    }
}
