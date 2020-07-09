using Microsoft.EntityFrameworkCore;
using Rrezart.Vibe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Application.Interfaces
{
    public interface IVibeDbContext
    {
        DbSet<Album> Albums { get; set; }
        DbSet<Artist> Artists { get; set; }
        DbSet<Enviroment> Enviroments { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Playlist> Playlists { get; set; }
        DbSet<PlaylistSongs> PlaylistSongs { get; set; }
        DbSet<Song> Songs { get; set; }
        DbSet<SongGenre> SongGenres { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
