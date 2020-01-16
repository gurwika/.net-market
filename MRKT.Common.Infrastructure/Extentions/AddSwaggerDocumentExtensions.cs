using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using NSwag;

namespace MRKT.Common.Infrastructure.Extentions
{
    public static class AddSwaggerDocumentExtensions
    {
        public static IServiceCollection AddSwaggerDocument(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddOpenApiDocument(options =>
            {
                options.DocumentName = "MRKT-app";
                options.Title = "MRKT-app api";
                options.Description = "MRKT-app description";

                options.GenerateEnumMappingDescription = true;

                var accessTokenSecurityScheme = new OpenApiSecurityScheme();
                accessTokenSecurityScheme.AuthorizationUrl = "http://localhost:62744";
                accessTokenSecurityScheme.Flow = OpenApiOAuth2Flow.Password;
                accessTokenSecurityScheme.Scheme = JwtBearerDefaults.AuthenticationScheme;
                accessTokenSecurityScheme.Type = OpenApiSecuritySchemeType.ApiKey;
                accessTokenSecurityScheme.In = OpenApiSecurityApiKeyLocation.Header;
                accessTokenSecurityScheme.Name = "Authorization";
                accessTokenSecurityScheme.Description = "Copy 'Bearer ' + valid JWT token into field";

                options.AddSecurity("MRKT-app bearer token", new[] { "profile", "offline_access" }, accessTokenSecurityScheme);
            });
        }
    }
}
