using Rrezart.Vibe.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Playlists.Queries.Get
{
    public class GetPlaylistsQueryModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<SongModel> Songs { get; set; } = new List<SongModel>();
    }
}
