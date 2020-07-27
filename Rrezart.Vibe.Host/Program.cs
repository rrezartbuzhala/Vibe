using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rrezart.Vibe.Application.Interfaces;
using Rrezart.Vibe.Persistence;

namespace Rrezart.Vibe.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using(var scope = host.Services.CreateScope())
            {
                var dbContext = (VibeDbContext)scope.ServiceProvider.GetRequiredService<IVibeDbContext>();
                dbContext.Database.Migrate();
                VibeDbContextInitializer.Initialize(dbContext);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}


