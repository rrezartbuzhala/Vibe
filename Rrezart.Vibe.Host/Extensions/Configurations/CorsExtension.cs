using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Rrezart.Vibe.Host.Extensions.Configurations
{
    public static class CorsExtension
    {
        private static string corsName = "SiteCors";
        public static void RegisterCors(this IServiceCollection services)
        {
            services.AddCors(options =>
                options.AddPolicy(corsName, builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            ));
        }
        public static void AddCors(this IApplicationBuilder app)
        {
            app.UseCors(corsName);
        }
    }
}
