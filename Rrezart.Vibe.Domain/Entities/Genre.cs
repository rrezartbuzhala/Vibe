using Rrezart.Vibe.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Domain.Entities
{
    public class Genre : Entity
    {
        public string GenreName { get; set; }
        public ICollection<SongGenre> SongGenre {get; set;}
    }
}
