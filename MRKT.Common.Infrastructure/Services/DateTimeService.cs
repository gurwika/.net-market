using MRKT.Common.Application.Common.Abstraction;
using System;

namespace MRKT.Common.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.Now;

        public int CurrentYear => DateTime.Now.Year;
    }
}
