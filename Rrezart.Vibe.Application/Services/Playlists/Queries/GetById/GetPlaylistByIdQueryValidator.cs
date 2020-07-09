using FluentValidation;
using Rrezart.Vibe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Playlists.Queries.GetById
{
    public class GetPlaylistByIdQueryValidator : AbstractValidator<GetPlaylistByIdQuery>
    {
        private readonly IVibeDbContext _context;
        public GetPlaylistByIdQueryValidator(IVibeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Validations();

        }
        private void Validations()
        {
            RuleFor(x => x.Id).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Id must not be null")
                .NotEmpty().WithMessage("Id must not be empty")
                .Must((id) =>
                {
                    return _context.Playlists.Any(x => x.Id == id);
                }).WithMessage("Playlist does not exist");

        }
    }
}
