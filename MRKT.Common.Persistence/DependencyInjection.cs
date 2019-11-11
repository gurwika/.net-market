using IdentityServer4.Models;
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
              .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
              {
                  options.Clients.Add(new Client
                  {
                      ClientId = "Identity.api",
                      AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                      ClientSecrets = { new Secret("Identity.Secret".Sha256()) },
                      AllowedScopes = { "MRKT.Identity.LauncherAPI" }
                  });
                  options.Clients.Add(new Client
                  {
                      ClientId = "Product.api",
                      ClientSecrets = { new Secret("Product.Secret".Sha256()) },
                      AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                      AllowedScopes = { "MRKT.Identity.LauncherAPI", "MRKT.Product.LauncherAPI" }
                  });
                  options.Clients.Add(new Client
                  {
                      ClientId = "Payment.api",
                      ClientSecrets = { new Secret("Payment.Secret".Sha256()) },
                      AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                      AllowedScopes = { "MRKT.Identity.LauncherAPI", "MRKT.Product.LauncherAPI", "MRKT.Payment.LauncherAPI" }
                  });

                  options.ApiResources.Add(new ApiResource("MRKT.Product.LauncherAPI", "product service"));
                  options.ApiResources.Add(new ApiResource("MRKT.Payment.LauncherAPI", "payment service"));
              });

            services.AddAuthentication()
                .AddIdentityServerJwt();

            return services;
        }
    }
}
