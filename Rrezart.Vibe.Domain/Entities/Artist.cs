using Rrezart.Vibe.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Domain.Entities
{
    public class Artist : Entity
    {
        public string Name { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
