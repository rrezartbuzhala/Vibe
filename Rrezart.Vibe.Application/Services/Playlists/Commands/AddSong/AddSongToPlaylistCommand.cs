using MediatR;
using Rrezart.Vibe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Playlists.Commands.AddSong
{
    public class AddSongToPlaylistCommand : IRequest<Unit>
    {
        public Guid SongId { get; set; }
        public Guid PlaylistId { get; set; }

        public PlaylistSongs ToEntity()
        {
            return new PlaylistSongs
            {
                SongId = SongId,
                PlaylistId = PlaylistId,
            };
        }
    }
}
