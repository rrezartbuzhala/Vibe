using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rrezart.Vibe.Host.Extensions.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Host.Extensions
{
    public static class ServiceExtension
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDbContext(configuration);
            services.RegisterAuthentication(configuration);
            services.RegiaterMediator();
            services.RegisterSwagger();
            services.RegisterCors();
        }
        public static void UseServices(this IMvcBuilder builder)
        {
            builder.UseValidations();
            
        }
        public static void AddServices(this IApplicationBuilder app)
        {
            app.AddSwagger();
            app.AddAuthentication();
            app.AddCors();
            
        }
    }
}
