﻿using MRKT.Common.Domain.Common.Abstraction.Events;
using System;

namespace MRKT.Common.Domain.Entities.Production.Events
{
    public class ProductDetailUpdatedEvent : IEvent
    {
        public Guid Id { get; protected set; }
        public string Payload { get; protected set; }

        public ProductDetailUpdatedEvent(
            Guid id,
            string payload
        )
        {
            Id = id;
            Payload = payload;
        }
    }
}
