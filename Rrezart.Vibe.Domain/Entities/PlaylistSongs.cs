using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Domain.Entities
{
    public class PlaylistSongs
    {
        public Guid SongId { get; set; }
        public Guid PlaylistId { get; set; }
        public Song Song { get; set; }
        public Playlist Playlist { get; set; }

    }
}
