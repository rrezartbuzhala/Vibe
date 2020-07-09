using MediatR;
using Microsoft.EntityFrameworkCore;
using Rrezart.Vibe.Application.Interfaces;
using Rrezart.Vibe.Application.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Application.Services.Songs.Queries.GetById
{
    public class GetSongByIdQueryHandler : IRequestHandler<GetSongByIdQuery, GetSongByIdQueryModel>
    {
        private readonly IVibeDbContext _context;


        public GetSongByIdQueryHandler(IVibeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<GetSongByIdQueryModel> Handle(GetSongByIdQuery request, CancellationToken cancellationToken)
        {
            var song = (from songs in _context.Songs
                        where songs.Id == request.Id
                        let genres = songs.SongGenre
                        let playlists = songs.PlaylistSongs
                        select new GetSongByIdQueryModel
                        {
                            Artist = songs.Artist.Name,
                            Album = songs.Album.Title,
                            Environment = songs.Enviroment.EnviromentName,
                            Title = songs.Title,
                            AudioSource = songs.AudioSource,
                            Minutage = songs.Minutage,
                            RegistredDate = songs.RegistredDate,
                            CoverSource = songs.CoverSource,
                            Genres = genres.Select(songGenre => new GenreModel
                            {
                                //Id = songGenre.Genre.Id,
                                GenreName = songGenre.Genre.GenreName
                            }),
                            Playlists = playlists.Select(playlist => new PlaylistModel
                            {
                                Title = playlist.Playlist.Title,
                                LastUpdated = playlist.Playlist.LastUpdated,
                                CoverSource = playlist.Playlist.CoverSource,
                            }),
                        });
            return await song.FirstOrDefaultAsync();
        }
    }
}
