using FluentValidation;
using Rrezart.Vibe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Playlists.Commands.AddSong
{
    public class AddSongToPlaylistCommandValidator : AbstractValidator<AddSongToPlaylistCommand>
    {
        private readonly IVibeDbContext _context;

        public AddSongToPlaylistCommandValidator(IVibeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Validations();
        }
        private void Validations()
        {
            RuleFor(x => x.PlaylistId).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Playlist must not be null")
                .NotEmpty().WithMessage("Playlist must not be empty")
                .Must((id) => 
                {
                    return _context.Playlists.Any(x => x.Id == id);
                }).WithMessage("Playlist does not exist");

            RuleFor(x => x.SongId).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Song must not be null")
                .NotEmpty().WithMessage("Song must not be empty")
                .Must((id) =>
                 {
                     return _context.Songs.Any(x => x.Id == id);
                 }).WithMessage("Song does not exist");
        }
    }
}
