using System;

namespace MRKT.Common.Domain.Exceptions
{
    public class InvalidEmailAddressrException : DomainException
    {
        public InvalidEmailAddressrException(string emailAddress, Exception ex) : base($"Email \"{emailAddress}\" is invalid.", ex) { }
    }
}
