using FluentValidation;
using Rrezart.Vibe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Genres.Queries.GetById
{
    public class GetGenreByIdQueryValidator : AbstractValidator<GetGenreByIdQuery>
    {
        private readonly IVibeDbContext _context;
        public GetGenreByIdQueryValidator(IVibeDbContext context)
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
                    return _context.Genres.Any(x => x.Id == id);
                }
                ).WithMessage("Genre dosen't exist!");
        }
    }
}
