using HomeBroker.Application.Interfaces;
using HomeBroker.Application.Services;
using HomeBroker.Domain.Core.Notifications;
using HomeBroker.Domain.Interfaces.Repositories;
using HomeBroker.Domain.Interfaces.Services;
using HomeBroker.Domain.Services;
using HomeBroker.Infrastructure.Data.Context;
using HomeBroker.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HomeBroker.Infrastructure.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Register Application - Services
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<ICotacaoAcaoAppService, CotacaoAcaoAppService>();
            services.AddScoped<IOrdemAppService, OrdemAppService>();

            // Register Domain - Services
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ICotacaoAcaoService, CotacaoAcaoService>();
            services.AddScoped<IOrdemService, OrdemService>();

            services.AddScoped<NotificationContext>();

            // Register Infrastructure - Data - Context
            services.AddScoped<DataContext>();

            // Register Infrastructure - Data - Repositories
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ICotacaoAcaoRepository, CotacaoAcaoRepository>();
            services.AddScoped<IOrdemRepository, OrdemRepository>();
        }
    }
}
