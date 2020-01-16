using System;
using System.Reflection;
using AutoMapper;
using EventStore.ClientAPI;
using EventStore.ClientAPI.SystemData;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MRKT.Product.Application.Common;

namespace MRKT.Product.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProductionApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddHostedService<ProductHostedSubscriber>();

            return services;
        }
    }
}
