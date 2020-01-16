using System;
using System.Collections.Generic;
using System.Text;

namespace MRKT.Common.Application.Common.Options
{
    public class EventStoreOptions
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string StreamName { get; set; }
        public string ConnectionString { get; set; }
    }
}
