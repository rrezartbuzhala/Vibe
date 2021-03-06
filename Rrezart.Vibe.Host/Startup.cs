using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rrezart.Vibe.Host.Extensions;
using Rrezart.Vibe.Host.Filters;
using Rrezart.Vibe.Host.Middleware;

namespace Rrezart.Vibe.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options => { 
                options.Filters.Add(new ExceptionFilter());
                options.Filters.Add(new ActionFilter());
            })
                .UseServices();
            services.RegisterServices(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.AddServices();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors("SiteCors");
            });
        }
    }
}
