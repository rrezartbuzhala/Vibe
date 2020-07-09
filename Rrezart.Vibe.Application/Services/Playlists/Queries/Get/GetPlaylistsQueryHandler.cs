using MediatR;
using Microsoft.EntityFrameworkCore;
using Rrezart.Vibe.Application.Interfaces;
using Rrezart.Vibe.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Application.Services.Playlists.Queries.Get
{
    public class GetPlaylistsQueryHandler : IRequestHandler<GetPlaylistsQuery, IList<GetPlaylistsQueryModel>>
    {
        private readonly IVibeDbContext _context;
        public GetPlaylistsQueryHandler(IVibeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IList<GetPlaylistsQueryModel>> Handle(GetPlaylistsQuery request, CancellationToken cancellationToken)
        {
            var playlists = (from playlist in _context.Playlists
                             let songs = playlist.PlaylistSongs
                             select new GetPlaylistsQueryModel
                             {
                                 Id = playlist.Id,
                                 Title = playlist.Title,
                                 Songs = songs.Select(song => new SongModel 
                                 { 
                                    Id = song.SongId,
                                    Title = song.Song.Title
                                 } 
                                 )
                             }
                             );
            return await playlists.ToListAsync();
        }
    }
}
