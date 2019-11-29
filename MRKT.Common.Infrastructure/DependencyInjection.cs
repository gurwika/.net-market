using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MRKT.Common.Application.Common.Abstraction;
using MRKT.Common.Application.Common.Options;
using MRKT.Common.Infrastructure.Common;
using MRKT.Common.Infrastructure.Services;

namespace MRKT.Common.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCommonInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EventStoreOptions>(options => configuration.GetSection("EventStore").Bind(options));

            services.AddScoped<IEventBus, EventBus>();
            services.AddTransient<IApplicationEventStore, ApplicationEventStore>();

            services.AddScoped<IUserManagerService, UserManagerService>();
            services.AddScoped<IUserRoleManagerService, UserRoleManagerService>();
            services.AddTransient<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IDateTimeService, DateTimeService>();

            return services;
        }
    }
}
