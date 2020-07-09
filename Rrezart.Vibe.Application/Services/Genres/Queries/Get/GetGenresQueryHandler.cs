using MediatR;
using Microsoft.EntityFrameworkCore;
using Rrezart.Vibe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Application.Services.Genres.Queries.Get
{
    public class GetGenresQueryHandler : IRequestHandler<GetGenresQuery, IList<GetGenresQueryModel>>
    {
        private readonly IVibeDbContext _context;
        public GetGenresQueryHandler(IVibeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IList<GetGenresQueryModel>> Handle(GetGenresQuery request, CancellationToken cancellationToken)
        {
            return await _context.Genres.Select(genre => new GetGenresQueryModel 
            { 
                Id = genre.Id,
                Name = genre.GenreName,
            }
            ).ToListAsync();
        }
    }
}
 