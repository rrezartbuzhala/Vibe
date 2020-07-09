using Rrezart.Vibe.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Domain.Entities
{
    public class Album : Entity
    {
        public Guid ArtistId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CoverSource{ get; set; }

        public Artist Artist { get; set; }

        public ICollection<Song> Songs { get; set; }
 
    }
}
