using Rrezart.Vibe.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Playlists.Queries.GetById
{
    public class GetPlaylistByIdQueryModel
    {
        public string Title { get; set; }
        public IEnumerable<SongModel> Songs { get; set; } = new List<SongModel>();
    }
}
