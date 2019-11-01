using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MRKT.Common.Application.Common.Abstraction;
using MRKT.Common.Infrastructure.Services;

namespace MRKT.Common.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCommonInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserManagerService, UserManagerService>();
            services.AddScoped<IUserRoleManagerService, UserRoleManagerService>();
            services.AddTransient<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IDateTimeService, DateTimeService>();

            return services;
        }
    }
}
