using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using MRKT.Common.Application.Context.Abstraction;
using MRKT.Common.Infrastructure.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MRKT.Common.Infrastructure.Extentions
{
    public static class ControllersInfrastructureExtentions
    {
        public static IMvcBuilder AddControllersInfrastructure(this IMvcBuilder builder)
        {
            return builder
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.TypeNameHandling = TypeNameHandling.Objects;
                    options.SerializerSettings.DateFormatString = SystemFormats.ShortDatePattern;
                    options.SerializerSettings.Converters.Add(new IsoDateTimeConverter() { DateTimeFormat = SystemFormats.LongDatePattern });
                })
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IApplicationDbContext>());
        }
    }
}
