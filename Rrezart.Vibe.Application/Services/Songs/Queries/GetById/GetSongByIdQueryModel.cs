using Rrezart.Vibe.Application.Models;
using System;
using System.Collections.Generic;

namespace Rrezart.Vibe.Application.Services.Songs.Queries.GetById
{
    public class GetSongByIdQueryModel
    {
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Environment { get; set; }
        public string Title { get; set; }
        public string AudioSource { get; set; }
        public int Minutage { get; set; }
        public string CoverSource { get; set; }
        public string RegistredDate { get; set; }
        public IEnumerable<GenreModel> Genres { get; set; } = new List<GenreModel>();
        public IEnumerable<PlaylistModel> Playlists { get; set; } = new List<PlaylistModel>();
        

    }
}
