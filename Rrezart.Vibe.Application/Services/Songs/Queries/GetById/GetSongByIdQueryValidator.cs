using FluentValidation;
using Rrezart.Vibe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Songs.Queries.GetById
{
    public class GetSongByIdQueryValidator : AbstractValidator<GetSongByIdQuery>
    {
        public readonly IVibeDbContext _context; 
        public GetSongByIdQueryValidator(IVibeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Validations();
        }
        private void Validations()
        {
            RuleFor(x => x.Id).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Song Id must not be null")
                .NotEmpty().WithMessage("Song Id must not be empty")
                .Must((id) =>
                {
                    return _context.Songs.Any(x => x.Id == id);
                }
                );
        }
    }
}
