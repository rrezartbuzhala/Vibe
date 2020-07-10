using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rrezart.Vibe.Application.Interfaces;
using Rrezart.Vibe.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Application.Services.Artists.Queries
{
    public class Get
    {
        public class Query : IRequest<IList<Response>>
        {

        }

        public class QueryHandler : IRequestHandler<Query,IList<Response>>
        {
            private readonly IVibeDbContext _context;
            public QueryHandler(IVibeDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }
            public async Task<IList<Response>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context
                    .Artists.AsNoTracking()
                    .Select(artist => new Response
                    {
                        Id = artist.Id,
                        Name = artist.Name,
                        Songs = artist.Songs.Select(song => new SongModel
                        {
                            Id = song.Id,
                            Title = song.Title,
                        }
                        ),
                    }
                    ).ToListAsync();
            }
        }

        public class Response
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public IEnumerable<SongModel> Songs { get; set; } = new List<SongModel>();
        }
    }
}
