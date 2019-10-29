using MediatR;
using System;

namespace MRKT.Common.Domain.Common.Abstraction.Events
{
    public interface IEvent : INotification
    {
        Guid Id { get; }
    }
}
