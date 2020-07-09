using MediatR;
using Rrezart.Vibe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Application.Services.Playlists.Commands.Add
{
    public class AddPlaylistCommandHandler : IRequestHandler<AddPlaylistCommand, Unit>
    {
        private readonly IVibeDbContext _context;
        public AddPlaylistCommandHandler(IVibeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Unit> Handle(AddPlaylistCommand request, CancellationToken cancellationToken)
        {
            _context.Playlists.Add(request.ToEntity());
            await _context.SaveChangesAsync();
            return Unit.Value;  
        }
    }
}
