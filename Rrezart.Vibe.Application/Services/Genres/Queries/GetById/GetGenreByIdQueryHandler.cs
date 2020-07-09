using MediatR;
using Microsoft.EntityFrameworkCore;
using Rrezart.Vibe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Application.Services.Genres.Queries.GetById
{
    public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, GetGenreByIdQueryModel>
    {
        private readonly IVibeDbContext _context;

        public GetGenreByIdQueryHandler(IVibeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<GetGenreByIdQueryModel> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            var genre = await  _context.Genres.FirstOrDefaultAsync(x => x.Id == request.Id);
            return new GetGenreByIdQueryModel
            {
                Name = genre.GenreName,
            };
        }
        
    }
}
