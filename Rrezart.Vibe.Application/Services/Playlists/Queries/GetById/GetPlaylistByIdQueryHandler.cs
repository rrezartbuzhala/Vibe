using MediatR;
using Rrezart.Vibe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Rrezart.Vibe.Application.Models;

namespace Rrezart.Vibe.Application.Services.Playlists.Queries.GetById
{
    public class GetPlaylistByIdQueryHandler : IRequestHandler<GetPlaylistByIdQuery, GetPlaylistByIdQueryModel>
    {
        private readonly IVibeDbContext _context;
        public GetPlaylistByIdQueryHandler(IVibeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<GetPlaylistByIdQueryModel> Handle(GetPlaylistByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context
                .Playlists.AsNoTracking()
                .Where(playlist => playlist.Id == request.Id)
                .Select(playlist => new GetPlaylistByIdQueryModel 
                {
                    Title = playlist.Title,
                    Songs = playlist.PlaylistSongs.Select(song => new SongModel 
                    {
                        Id = song.SongId,
                        Title = song.Song.Title,
                    }
                    ),
                }
                ).FirstOrDefaultAsync();
        }
    }
}
