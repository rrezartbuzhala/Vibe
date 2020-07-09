using FluentValidation.Results;
using MediatR;
using Rrezart.Vibe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Application.Services.Artists.Commands.Add
{
    public class AddArtistCommandHandler : IRequestHandler<AddArtistCommand, Unit>
    {
        private readonly IVibeDbContext _context;
        public AddArtistCommandHandler(IVibeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(AddArtistCommand request, CancellationToken cancellationToken)
        {
            _context.Artists.Add(request.ToEntity());
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
