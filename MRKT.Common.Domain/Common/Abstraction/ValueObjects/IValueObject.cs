using System;
using System.Collections.Generic;
using System.Text;

namespace MRKT.Common.Domain.Common.Abstraction.ValueObjects
{
    public interface IValueObject
    {
        int GetHashCode();
        bool Equals(object obj);
    }
}
