using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Rrezart.Vibe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Artists.Queries.GetById
{
    public class GetArtistByIdQueryValidator : AbstractValidator<GetArtistByIdQuery>
    {
        private readonly IVibeDbContext _context;
        public GetArtistByIdQueryValidator(IVibeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Validations();
        }

        private void Validations()
        {
            RuleFor(x => x.Id).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Artist Id must not be null")
                .NotEmpty().WithMessage("Artist Id must not be empty")
                .Must((id) =>
                {
                    return _context.Artists.Any(x => x.Id == id);
                }
                ).WithMessage("Artist dosen't exist!");
        }
    }
}
