using MediatR;
using Rrezart.Vibe.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Application.Services.Playlists.Commands.AddSong
{
    public class AddSongToPlaylistCommandHandler : IRequestHandler<AddSongToPlaylistCommand, Unit>
    {
        private readonly IVibeDbContext _context;
        public AddSongToPlaylistCommandHandler(IVibeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Unit> Handle(AddSongToPlaylistCommand request, CancellationToken cancellationToken)
        {
            _context.PlaylistSongs.Add(request.ToEntity());

            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
