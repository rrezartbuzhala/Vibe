using System;

namespace Rrezart.Vibe.Domain.Entities
{
    public class SongGenre
    {
        public Guid SongId { get; set; }
        public Guid GenreId { get; set; }

        public Song Song { get; set; }
        public Genre Genre { get; set; }
    }
}
