using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Rrezart.Vibe.Application.Services.Songs.Queries.GetById;

namespace Rrezart.Vibe.Host.Extensions.Configurations
{
    public static class MediatorExtension
    {
        public static void RegiaterMediator(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetSongByIdQuery).Assembly);
        }
    }
}
