﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MRKT.Product.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProductionApplication(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
