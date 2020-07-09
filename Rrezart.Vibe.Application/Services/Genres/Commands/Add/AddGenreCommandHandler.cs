using MediatR;
using Rrezart.Vibe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Application.Services.Genres.Commands.Add
{
    public class AddGenreCommandHandler : IRequestHandler<AddGenreCommand, Unit>
    {
        private readonly IVibeDbContext _context;
        public AddGenreCommandHandler(IVibeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Unit> Handle(AddGenreCommand request, CancellationToken cancellationToken)
        {
            _context.Genres.Add(request.ToEntity());
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
