using System;

namespace MRKT.Common.Domain.Exceptions
{
    public class InvalidPhoneNumberException : DomainException
    {
        public InvalidPhoneNumberException(string phoneNumber, Exception ex) : base($"Phone number \"{phoneNumber}\" is invalid.", ex) { }
    }
}
