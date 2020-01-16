using MRKT.Common.Application.Common.Abstraction;
using MRKT.Common.Domain.Common.Abstraction.Events;
using MRKT.Common.Infrastructure.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MRKT.Common.Infrastructure.Common
{
    public class StoredEventSerializer : IStoredEventSerializer
    {
        private readonly Assembly _eventTypesAssembly;

        public StoredEventSerializer(Assembly eventTypesAssembly)
        {
            _eventTypesAssembly = eventTypesAssembly;
        }

        public IEvent As(string type, byte[] data)
        {
            return As(type, Encoding.UTF8.GetString(data));
        }

        public IEvent As(string type, string objectJson)
        {
            if (string.IsNullOrEmpty(objectJson))
            {
                return default(IEvent);
            }

            var assemblyEventType = _eventTypesAssembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                DateFormatString = SystemFormats.ShortDatePattern,
            };

            settings.Converters.Add(new IsoDateTimeConverter() { DateTimeFormat = SystemFormats.LongDatePattern });

            return (IEvent) JsonConvert.DeserializeObject(objectJson, assemblyEventType, settings);
        }
    }
}
