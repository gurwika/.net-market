using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MRKT.Common.Application;
using MRKT.Common.Application.Context.Abstraction;
using MRKT.Common.Infrastructure;
using MRKT.Common.Infrastructure.Extentions;
using MRKT.Common.Infrastructure.Middlewares;
using MRKT.Common.Infrastructure.Utils;
using MRKT.Common.Persistence;
using MRKT.Identity.Application;
using MRKT.Identity.Persistence;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NSwag;
using System.Reflection;

namespace MRKT.Identity.Launcher
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
            services.AddIdentityApplication();

            services.AddIdentityPersistence(Configuration);
            services.AddCommonAuthentication();

            services.AddHttpContextAccessor();

            services.AddControllers()
                .AddControllersInfrastructure();

            services.AddSwaggerDocument();

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
            app.UseIdentityServer();
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
