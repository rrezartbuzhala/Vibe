using MediatR;
using Rrezart.Vibe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Rrezart.Vibe.Application.Models;

namespace Rrezart.Vibe.Application.Services.Artists.Queries.Get
{
    public class GetArtistsQueryHandler : IRequestHandler<GetArtistsQuery, IList<GetArtistsQueryModel>>
    {
        private readonly IVibeDbContext _context;
        public GetArtistsQueryHandler(IVibeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IList<GetArtistsQueryModel>> Handle(GetArtistsQuery request, CancellationToken cancellationToken)
        {
            return await _context
                .Artists.AsNoTracking()
                .Select(artist => new GetArtistsQueryModel 
                {
                    Id = artist.Id,
                    Name = artist.Name,
                    Songs = artist.Songs.Select(song => new SongModel 
                    {
                        Id = song.Id,
                        Title = song.Title,
                    }
                    ),
                } 
                ).ToListAsync();
        }
    }
}
