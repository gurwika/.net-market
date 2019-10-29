using System;

namespace MRKT.Common.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException() { }

        public DomainException(string message) : base(message) {  }

        public DomainException(string message, Exception ex) : base(message, ex) {  }
    }
}
