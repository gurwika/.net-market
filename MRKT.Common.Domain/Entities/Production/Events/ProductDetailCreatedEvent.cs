﻿using MRKT.Common.Domain.Common.Abstraction.Events;
using System;

namespace MRKT.Common.Domain.Entities.Production.Events
{
    public class ProductDetailCreatedEvent : IEvent
    {
        public Guid Id { get; protected set; }
        public string Data { get; protected set; }

        public ProductDetailCreatedEvent(
            Guid id,
            string data
        )
        {
            Id = id;
            Data = data;
        }
    }
}
