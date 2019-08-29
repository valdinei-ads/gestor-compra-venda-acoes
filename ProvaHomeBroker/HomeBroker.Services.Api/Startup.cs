using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using HomeBroker.Infrastructure.CrossCutting.IoC;
using HomeBroker.Services.Api.Configurations;
using Newtonsoft.Json.Converters;

namespace HomeBroker.Services.Api
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebApi(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                options.UseCentralRoutePrefix(new RouteAttribute("api/v{version}"));
            });
            services.AddMvc().AddJsonOptions(op => {
                 op.SerializerSettings.Converters.Add(new StringEnumConverter());
             });

            //services.AddMvc(options => options.Filters.Add<NotificationFilter>())
            //        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1); ;

            services.AddAutoMapperSetup();

            // .NET Native DI Abstraction
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseStaticFiles();
            app.UseMvc();

            //app.UseSwagger();
            //app.UseSwaggerUI(s =>
            //{
            //    s.SwaggerEndpoint("/swagger/v1/swagger.json", "ClienteCRUD Project API v1.1");
            //});
        }

        private static void RegisterServices(IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
