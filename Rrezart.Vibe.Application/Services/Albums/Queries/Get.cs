using MediatR;
using Microsoft.EntityFrameworkCore;
using Rrezart.Vibe.Application.Exceptions;
using Rrezart.Vibe.Application.Interfaces;
using Rrezart.Vibe.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Application.Services.Albums.Queries
{
    public class Get
    {
        public class Query : IRequest<IList<Response>>
        {

        }

        public class Response
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string CoverSource { get; set; }

            public ArtistModel Artist { get; set; }
            public IEnumerable<SongModel> Songs { get; set; } = new List<SongModel>();
        }

        public class QueryHandler : IRequestHandler<Query, IList<Response>>
        {
            private readonly IVibeDbContext _context;

            public QueryHandler(IVibeDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }
            public async Task<IList<Response>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context
                    .Albums
                    .Select(album => new Response
                    {
                        Id = album.Id,
                        Artist = new ArtistModel
                        {
                            Name = album.Artist.Name
                        },
                        Title = album.Title,
                        ReleaseDate = album.ReleaseDate,
                        CoverSource = album.CoverSource,
                        Songs = album.Songs.Select(songs => new SongModel
                        {
                            Id = songs.Id,
                            Title = songs.Title,

                        }),


                    }).ToListAsync();
            }
        }
    }
}
