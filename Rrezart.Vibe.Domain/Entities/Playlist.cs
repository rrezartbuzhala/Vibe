using Rrezart.Vibe.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Domain.Entities
{
    public class Playlist : Entity
    {
        public string Title { get; set; }
        public DateTime LastUpdated { get; set; }
        public string CoverSource { get; set; }

        public ICollection<PlaylistSongs> PlaylistSongs { get; set; }
    }
}
