using Rrezart.Vibe.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Enviroments.Queries.Get
{
    public class GetEnviromentsQueryModel
    {
        public Guid Id { get; set; }
        public string EnviromentName { get; set; }

        public IEnumerable<SongModel> Songs { get; set; }
    }
}
