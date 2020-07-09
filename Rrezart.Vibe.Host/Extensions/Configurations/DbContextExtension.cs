using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rrezart.Vibe.Application.Interfaces;
using Rrezart.Vibe.Persistence;
using System;

namespace Rrezart.Vibe.Host.Extensions.Configurations
{
    public static class DbContextExtension
    {
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("VibeDatabase");
            services.AddDbContext<VibeDbContext>(options => 
                options.UseSqlServer(connectionString)
            );

            services.AddScoped<IVibeDbContext, VibeDbContext>();
        }
    }
}
