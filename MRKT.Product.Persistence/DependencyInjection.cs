using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IdentityServer4.Models;
using MRKT.Common.Domain.Entities.Application;
using MRKT.Common.Persistence.Context;
using MRKT.Common.Persistence;

namespace MRKT.Product.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProductPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityServer(options =>
            {
                options.IssuerUri = "https://myidentity.com";
            })
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
              {
                  options.Clients.Add(new Client
                  {
                      ClientId = "Payment.api",
                      ClientSecrets = { new Secret("Payment.Secret".Sha256()) },
                      AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                      AllowedScopes = { "MRKT.Identity.LauncherAPI", "MRKT.Product.LauncherAPI", "MRKT.Payment.LauncherAPI" }
                  });

                  options.ApiResources.Add(new ApiResource("MRKT.Identity.LauncherAPI", "identity service"));
                  options.ApiResources.Add(new ApiResource("MRKT.Payment.LauncherAPI", "payment service"));
              })
            .AddSigningCredential(configuration.GetSection("SigninKeyCredentials"));

            return services;
        }
    }
}
