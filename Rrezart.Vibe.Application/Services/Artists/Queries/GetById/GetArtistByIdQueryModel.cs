using Rrezart.Vibe.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Artists.Queries.GetById
{
    public class GetArtistByIdQueryModel
    {
        public string Name { get; set; }
        public IEnumerable<SongModel> Songs { get; set; } = new List<SongModel>();
    }
}
