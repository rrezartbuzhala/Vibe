using MediatR;
using Microsoft.EntityFrameworkCore;
using Rrezart.Vibe.Application.Interfaces;
using Rrezart.Vibe.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Application.Services.Songs.Queries.Get
{
    public class GetSongsQueryHandler : IRequestHandler<GetSongsQuery, IList<GetSongsQueryModel>>
    {
        private readonly IVibeDbContext _context;

        public GetSongsQueryHandler(IVibeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IList<GetSongsQueryModel>> Handle(GetSongsQuery request, CancellationToken cancellationToken)
        {
            var songs = (from song in _context.Songs
                         let genres = song.SongGenre
                         let playlist = song.PlaylistSongs
                         select new GetSongsQueryModel 
                         {
                             Id = song.Id,
                             Artist = song.Artist.Name,
                             Album = song.Album.Title,
                             Environment = song.Enviroment.EnviromentName,
                             Title = song.Title,
                             AudioSource = song.AudioSource,
                             Minutage = song.Minutage,
                             RegistredDate = song.RegistredDate,
                             CoverSource = song.CoverSource,
                             Genres = genres.Select(songGenre => new GenreModel
                             {
                                 Id = songGenre.Genre.Id,
                                 GenreName = songGenre.Genre.GenreName
                             }),
                             Playlists = playlist.Select(playlist => new PlaylistModel
                             {
                                 Title = playlist.Playlist.Title,
                                 LastUpdated = playlist.Playlist.LastUpdated,
                                 CoverSource = playlist.Playlist.CoverSource,
                             }),
                         }
                        );
            return await songs.ToListAsync();

        }
    }
}
