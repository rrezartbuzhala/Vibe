using FluentValidation;
using Rrezart.Vibe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Application.Services.Artists.Commands.Add
{
    public class AddArtistCommandValidator : AbstractValidator<AddArtistCommand>
    {
        public AddArtistCommandValidator()
        {
            Validations();
        }
        public void Validations()
        {
            RuleFor(x => x.Name).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Name must not be null")
                .NotEmpty().WithMessage("Name must not be empty!");
        }
    }

}
