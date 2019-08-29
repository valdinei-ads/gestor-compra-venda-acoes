using System;
using AutoMapper;
using HomeBroker.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace HomeBroker.Services.Api.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper();

            // register the Mappings beetween ViewModel e Model
            AutoMapperConfig.RegisterMappings();
        }
    }
}
