using System;
using System.Collections.Generic;
using System.Text;

namespace MRKT.Common.Application.Exceptions
{
    public class ApplicationException : Exception
    {
        public ApplicationException() { }

        public ApplicationException(string message) : base(message) { }

        public ApplicationException(string message, Exception ex) : base(message, ex) { }
    }
}
