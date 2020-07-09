using Rrezart.Vibe.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Domain.Entities
{
    public class Song : Entity
    {
        public Guid ArtistId { get; set; }
        public Guid AlbumId { get; set; }
        public Guid EnviromentId { get; set; }
        public string Title { get; set; }
        public string AudioSource { get; set; }
        public int Minutage { get; set; }
        public string CoverSource { get; set; }
        public string RegistredDate { get; set; }

        public ICollection<SongGenre> SongGenre { get; set; }
        public ICollection<PlaylistSongs> PlaylistSongs { get; set; }

        public Artist Artist { get; set; }
        public Album Album { get; set; }
        public Enviroment Enviroment { get; set; }


    }
}
