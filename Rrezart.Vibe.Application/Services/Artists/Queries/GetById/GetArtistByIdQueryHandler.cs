using MediatR;
using Microsoft.EntityFrameworkCore;
using Rrezart.Vibe.Application.Interfaces;
using Rrezart.Vibe.Application.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Application.Services.Artists.Queries.GetById
{
    public class GetArtistByIdQueryHandler : IRequestHandler<GetArtistByIdQuery, GetArtistByIdQueryModel>
    {
        private readonly IVibeDbContext _context;
        public GetArtistByIdQueryHandler(IVibeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<GetArtistByIdQueryModel> Handle(GetArtistByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context
               .Artists
               .Where(artist => artist.Id == request.Id)
               .Select(artist => new GetArtistByIdQueryModel
               {
                   Name = artist.Name,
                   Songs = artist.Songs.Select(song => new SongModel
                   {
                       Id = song.Id,
                       Title = song.Title,
                   }
                   ),
               }
               ).FirstOrDefaultAsync();
        }
    }
}
