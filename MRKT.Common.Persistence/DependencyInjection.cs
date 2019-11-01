using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MRKT.Common.Application.Context.Abstraction;
using MRKT.Common.Domain.Entities.Application;
using MRKT.Common.Persistence.Context;

namespace MRKT.Common.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCommonPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseLazyLoadingProxies()
                .UseNpgsql(
                    configuration.GetConnectionString("ApplicationDbContext"), 
                    x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName)
                )
            );

            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<IApplicationDbContext>(x => x.GetService<ApplicationDbContext>());

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            return services;
        }
    }
}
