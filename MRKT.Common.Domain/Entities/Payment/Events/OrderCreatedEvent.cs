﻿using MRKT.Common.Domain.Common.Abstraction.Events;
using System;

namespace MRKT.Common.Domain.Entities.Payments.Events
{
    public class OrderCreatedEvent : IEvent
    {
        public Guid Id { get; protected set; }
        public string Payload { get; protected set; }

        public OrderCreatedEvent(
            Guid id,
            string payload
        )
        {
            Id = id;
            Payload = payload;
        }
    }
}
