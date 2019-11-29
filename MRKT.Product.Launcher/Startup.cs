using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MRKT.Common.Application.Context.Abstraction;
using MRKT.Common.Infrastructure;
using MRKT.Common.Infrastructure.Middlewares;
using MRKT.Common.Persistence;
using MRKT.Product.Application;
using MRKT.Product.Persistence;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NSwag;

namespace MRKT.Product.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCommonInfrastructure(Configuration);
            services.AddCommonPersistence(Configuration);
            services.AddProductPersistence(Configuration);
            services.AddCommonAuthentication();
            services.AddProductionApplication(Configuration);
            services.AddHttpContextAccessor();

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.TypeNameHandling = TypeNameHandling.Objects;
                    options.SerializerSettings.DateFormatString = "dd-MM-yyyy";
                    options.SerializerSettings.Converters.Add(new IsoDateTimeConverter() { DateTimeFormat = "dd-MM-yyyy HH:mm:ss.FFFFFFFK" });
                })
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IApplicationDbContext>());

            services.AddOpenApiDocument(options =>
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

            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCustomExceptionHandler();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseOpenApi();

            app.UseSwaggerUi3(settings =>
            {
                settings.Path = "/api";
                //    settings.DocumentPath = "/api/specification.json";   Enable when NSwag.MSBuild is upgraded to .NET Core 3.0
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}"
                );
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
