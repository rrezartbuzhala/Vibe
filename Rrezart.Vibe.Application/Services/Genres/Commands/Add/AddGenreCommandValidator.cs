using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Genres.Commands.Add
{
    public class AddGenreCommandValidator : AbstractValidator<AddGenreCommand>
    {
        public AddGenreCommandValidator()
        {
            Validations();
        }
        public void Validations()
        {
            RuleFor(x => x.GenreName).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Genre name must not be null")
                .NotEmpty().WithMessage("Genre name must not be empty!");
        }
    }
}
